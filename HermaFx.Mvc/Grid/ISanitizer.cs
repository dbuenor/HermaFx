﻿namespace HermaFx.Mvc.Grid
{
    /// <summary>
    ///     Object that sanitize dangerous content in Grid.Mvc
    /// </summary>
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}