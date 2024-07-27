// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace osu.Native
{
    // ReSharper disable once UnusedTypeParameter
    public interface INativeObject<out T>
    {
        IntPtr GetHandle();
    }

    public static class NativeObjectExtensions
    {
        /// <summary>
        /// Retrieves the underlying managed object referenced to by this <see cref="INativeObject{T}"/>.
        /// </summary>
        /// <param name="nativeObject">The native object.</param>
        /// <typeparam name="T">The underlying object type.</typeparam>
        /// <returns>The managed object.</returns>
        public static T Get<T>(this INativeObject<T> nativeObject)
        {
            return (T)Allocator.Dereference(nativeObject.GetHandle());
        }

        /// <summary>
        /// Deletes this <see cref="INativeObject{T}"/>, releasing all references to it.
        /// </summary>
        /// <param name="nativeObject">The native object.</param>
        /// <typeparam name="T">The underlying object type.</typeparam>
        public static void Delete<T>(this INativeObject<T> nativeObject)
        {
            Allocator.Delete(nativeObject.GetHandle());
        }
    }
}
