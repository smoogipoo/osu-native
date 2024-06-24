// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

// ReSharper disable once CheckNamespace

public enum ErrorCode : byte
{
    Success = 0,
    EmptyBeatmap = 1,
    FileReadError = 2,
    Failure = 255
}
