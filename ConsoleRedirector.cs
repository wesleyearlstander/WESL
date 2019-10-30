using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using UnityEngine;

namespace WESL
{
    /// <summary>
    /// Class to redirect console output to unity console
    /// </summary>
    public static class ConsoleRedirector
    {
        /// <summary>
        /// Unity text writer derived from text writer
        /// </summary>
        private class UnityTextWriter : TextWriter
        {
            private StringBuilder buffer = new StringBuilder();

            /// <summary>
            /// Prints console text to unity console and resets buffer
            /// </summary>
            public override void Flush()
            {
                Debug.Log(buffer.ToString());
                buffer.Length = 0;
            }

            /// <summary>
            /// Write string to unity console
            /// </summary>
            /// <param name="value">String to write</param>
            public override void Write(string value)
            {
                buffer.Append(value);
                if (value != null)
                {
                    var len = value.Length;
                    if (len > 0)
                    {
                        var lastChar = value[len - 1];
                        if (lastChar == '\n')
                        {
                            Flush();
                        }
                    }
                }
            }

            /// <summary>
            /// Write character to unity console
            /// </summary>
            /// <param name="value">Character to write to unity console</param>
            public override void Write(char value)
            {
                buffer.Append(value);
                if (value == '\n')
                {
                    Flush();
                }
            }

            /// <summary>
            /// Set encoding to default always
            /// </summary>
            public override Encoding Encoding
            {
                get { return Encoding.Default; }
            }
        }

        /// <summary>
        /// Redirect console output to unity console
        /// </summary>
        public static void Redirect()
        {
            if (Console.Out.GetType() != typeof(UnityTextWriter))
                Console.SetOut(new UnityTextWriter());
        }
    }
}
