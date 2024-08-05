// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace osu.Native
{
    public static unsafe class Allocator
    {
        private static readonly Dictionary<IntPtr, object> native_object_references = new Dictionary<IntPtr, object>();
        private static delegate* unmanaged<uint, void*> malloc;

        static Allocator()
        {
            malloc = &defaultMalloc;

            [UnmanagedCallersOnly]
            static void* defaultMalloc(uint numBytes) => NativeMemory.Alloc(numBytes);
        }

        /// <summary>
        /// Returns a pinned reference to an object.
        /// </summary>
        /// <param name="target">The object reference that may be unreferenced via <see cref="Dereference"/>.</param>
        /// <returns>The pinned reference.</returns>
        public static IntPtr Reference(object target)
        {
            IntPtr gcPtr = GCHandle.ToIntPtr(GCHandle.Alloc(null));

            lock (native_object_references)
                native_object_references[gcPtr] = target;

            return gcPtr;
        }

        /// <summary>
        /// Returns an object from a pinned reference to it.
        /// </summary>
        /// <param name="handle">The pinned reference to the object from <see cref="Reference"/>.</param>
        /// <returns>The object.</returns>
        public static object Dereference(IntPtr handle)
        {
            lock (native_object_references)
                return native_object_references[handle];
        }

        /// <summary>
        /// Deletes a pinned reference.
        /// </summary>
        /// <param name="handle">The pinned reference.</param>
        public static void Delete(IntPtr handle)
        {
            lock (native_object_references)
            {
                if (!native_object_references.Remove(handle, out object? reference))
                    return;

                if (reference is IDisposable disposable)
                    disposable.Dispose();

                GCHandle.FromIntPtr(handle).Free();
            }
        }

        /// <summary>
        /// Packs an array for marshalling to unmanaged code.
        /// </summary>
        /// <param name="objects">The array to pack.</param>
        public static T* Pack<T>(T[] objects)
            where T : unmanaged
        {
            T* nativeArray = (T*)malloc((uint)(Unsafe.SizeOf<T>() * objects.Length));

            for (int i = 0; i < objects.Length; i++)
                nativeArray[i] = objects[i];

            return nativeArray;
        }

        /// <summary>
        /// Packs an array for marshalling to unmanaged code.
        /// </summary>
        /// <param name="objects">The array to pack.</param>
        public static T** Pack<T>(T*[] objects)
            where T : unmanaged
        {
            T** nativeArray = (T**)malloc((uint)(IntPtr.Size * objects.Length));

            for (int i = 0; i < objects.Length; i++)
                nativeArray[i] = objects[i];

            return nativeArray;
        }

        /// <summary>
        /// Unpacks an array from unmanaged code for use in managed code.
        /// </summary>
        /// <param name="nativeArray">The array to unpack.</param>
        /// <param name="numElements">The number of elements in the array.</param>
        public static T[] Unpack<T>(T* nativeArray, int numElements)
            where T : unmanaged
        {
            T[] array = new T[numElements];

            for (int i = 0; i < numElements; i++)
                array[i] = nativeArray[i];

            return array;
        }

        /// <summary>
        /// Sets a custom allocator for objects that are allocated in the unmanaged heap.
        /// By default, malloc() is used.
        /// </summary>
        /// <param name="handler">A callback to handle the allocation.</param>
        [UnmanagedCallersOnly(EntryPoint = "SetAllocator", CallConvs = [typeof(CallConvCdecl)])]
        public static void SetAllocator(delegate* unmanaged<uint, void*> handler)
        {
            malloc = handler;
        }
    }
}
