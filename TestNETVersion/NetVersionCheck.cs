﻿#region License
/*
This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org/>
*/
#endregion

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestNETVersion
{
    /// <summary>
    /// A class to check NET version using the 'dotnet' command.
    /// </summary>
    public class NetVersionCheck
    {
        private const string AspNetCoreAll = "Microsoft.AspNetCore.All";
        private const string AspNetCoreApp = "Microsoft.AspNetCore.App";
        private const string NetCoreApp = "Microsoft.NETCore.App";
        private const string WindowsDesktopApp = "Microsoft.WindowsDesktop.App";

        /// <summary>
        /// Gets the maximum version of the specified NET application type.
        /// </summary>
        /// <param name="type">The type of the NET application.</param>
        /// <returns>System.Nullable&lt;Version&gt;.</returns>
        public static Version? GetMaxVersion(NetApplicationType type)
        {
            return GetAllVersions(type).Max();
        }

        /// <summary>
        /// Gets the minimum version of the specified NET application type.
        /// </summary>
        /// <param name="type">The type of the NET application.</param>
        /// <returns>System.Nullable&lt;Version&gt;.</returns>
        public static Version? GetMinVersion(NetApplicationType type)
        {
            return GetAllVersions(type).Min();
        }

        /// <summary>
        /// Gets all NET versions for the specified application type.
        /// </summary>
        /// <param name="type">The type of the application.</param>
        /// <returns>List&lt;Version&gt;.</returns>
        public static List<Version> GetAllVersions(NetApplicationType type)
        {
            using var processRunner = new ConsoleProcessRunner("dotnet", "--list-runtimes");
            processRunner.RunProcess();

            var versions = new List<Version>();

            switch (type)
            {
                case NetApplicationType.AspNetCoreAll:
                    versions = GetVersionFromLines(processRunner.ProcessOutput, AspNetCoreAll);
                    break;

                case NetApplicationType.AspNetCoreApp:
                    versions = GetVersionFromLines(processRunner.ProcessOutput, AspNetCoreApp);
                    break;

                case NetApplicationType.NetCoreApp:
                    versions = GetVersionFromLines(processRunner.ProcessOutput, NetCoreApp);
                    break;

                case NetApplicationType.WindowsDesktopApp:
                    versions = GetVersionFromLines(processRunner.ProcessOutput, WindowsDesktopApp);
                    break;
            }

            return versions;
        }

        /// <summary>
        /// Gets the version from output lines generated by the command: 'dotnet --list-runtimes'.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="start">The start.</param>
        /// <returns>List&lt;Version&gt;.</returns>
        internal static List<Version> GetVersionFromLines(string lines, string start)
        {
            var lineSplit = new List<string>(lines.Split(Environment.NewLine));
            lineSplit.RemoveAll(s => !s.StartsWith(start, StringComparison.Ordinal));

            try
            {
                var pattern = new Regex(@"\d+(\.\d+)+");
                return lineSplit.Select(f => Version.Parse(pattern.Match(f).Value)).OrderBy(f => f).ToList();
            }
            catch
            {
                return new List<Version>();
            }
        }
    }

    /// <summary>
    /// An enumeration for the NET application type to be used with the 'dotnet' command.
    /// </summary>
    public enum NetApplicationType
    {
        /// <summary>
        /// The "Microsoft.AspNetCore.All".
        /// </summary>
        AspNetCoreAll,

        /// <summary>
        /// The "Microsoft.AspNetCore.App".
        /// </summary>
        AspNetCoreApp,

        /// <summary>
        /// The "Microsoft.NETCore.App".
        /// </summary>
        NetCoreApp,
        
        /// <summary>
        /// The "Microsoft.WindowsDesktop.App".
        /// </summary>
        WindowsDesktopApp,
    }
}
#nullable restore