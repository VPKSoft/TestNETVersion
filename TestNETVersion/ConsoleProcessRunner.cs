#region License
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
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TestNETVersion
{
    /// <summary>
    /// A class to run a specified process either synchronously or asynchronously.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ConsoleProcessRunner: IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleProcessRunner"/> class.
        /// </summary>
        public ConsoleProcessRunner()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleProcessRunner"/> class.
        /// </summary>
        /// <param name="command">The command for the process to run.</param>
        /// <param name="arguments">The arguments for the process to run.</param>
        public ConsoleProcessRunner(string command, params object[]? arguments)
        {
            Command = command;
            if (arguments?.Length > 0)
            {
                Arguments = string.Join(" ", arguments);
            }
        }

        /// <summary>
        /// Creates a new process using the <see cref="Command"/> and <see cref="Arguments"/> property values.
        /// </summary>
        internal void CreateProcess()
        {
            ProcessOutputBuilder.Clear();
            ProcessErrorBuilder.Clear();

            try
            {
                // create a process..
                Process = new Process
                {
                    StartInfo =
                    {
                        FileName = Command,
                        Arguments = Arguments,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WorkingDirectory = WorkingDirectory ?? "",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };
            }
            catch
            {
                Process = null;
            }
        }

        /// <summary>
        /// Runs the process specified by the <see cref="Command"/> and <see cref="Arguments"/> properties.
        /// </summary>
        /// <returns>The exit code of the process.</returns>
        public int RunProcess()
        {
            CreateProcess();

            Process?.Start();

            if (Process != null)
            {
                while (!Process.StandardOutput.EndOfStream)
                {
                    ProcessOutputBuilder.Append(Process.StandardOutput.ReadLine() + Environment.NewLine);
                }

                while (!Process.StandardError.EndOfStream)
                {
                    ProcessErrorBuilder.Append(Process.StandardError.ReadLine() + Environment.NewLine);
                }

                Process.WaitForExit();
            }

            var result = Process?.ExitCode ?? -1;

            Process?.Dispose();
            Process = null;

            return result;
        }

        /// <summary>
        /// Runs the process asynchronously specified by the <see cref="Command"/> and <see cref="Arguments"/> properties.
        /// </summary>
        /// <returns>The exit code of the process.</returns>
        public async Task<int> RunProcessAsync()
        {
            CreateProcess();

            Process?.Start();

            if (Process != null)
            {
                await Process.WaitForExitAsync();

                while (!Process.StandardOutput.EndOfStream)
                {
                    ProcessOutputBuilder.Append(await Process.StandardOutput.ReadLineAsync() + Environment.NewLine);
                }

                while (!Process.StandardError.EndOfStream)
                {
                    ProcessErrorBuilder.Append(await Process.StandardError.ReadLineAsync() + Environment.NewLine);
                }
            }

            var result = Process?.ExitCode ?? -1;

            Process?.Dispose();
            Process = null;

            return result;
        }

        /// <summary>
        /// Gets the process identifier.
        /// </summary>
        /// <value>The process identifier.</value>
        internal int ProcessId
        {
            get
            {
                try
                {
                    return Process?.Id ?? 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets the process.
        /// </summary>
        /// <value>The process.</value>
        internal Process? Process { get; set; }

        /// <summary>
        /// Gets the <see cref="StringBuilder"/> instance for the process output.
        /// </summary>
        /// <value>The <see cref="StringBuilder"/> instance for the process output.</value>
        private StringBuilder ProcessOutputBuilder { get; } = new();

        /// <summary>
        /// Gets the <see cref="StringBuilder"/> instance for the process error output.
        /// </summary>
        /// <value>The <see cref="StringBuilder"/> instance for the process error output.</value>
        private StringBuilder ProcessErrorBuilder { get; } = new();

        /// <summary>
        /// Gets the process output.
        /// </summary>
        /// <value>The process output.</value>
        public string ProcessOutput => ProcessOutputBuilder.ToString();

        /// <summary>
        /// Gets the process error output.
        /// </summary>
        /// <value>The process error output.</value>
        public string ProcessError => ProcessErrorBuilder.ToString();

        /// <summary>
        /// Gets or sets the working directory of the process.
        /// </summary>
        /// <value>The working directory of the process.</value>
        public string? WorkingDirectory { get; set; }

        /// <summary>
        /// Gets or sets the command for the process.
        /// </summary>
        /// <value>The command for the process.</value>
        public string Command { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the arguments for the process.
        /// </summary>
        /// <value>The arguments for the process.</value>
        public string Arguments { get; set; } = string.Empty;

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Process?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
#nullable restore