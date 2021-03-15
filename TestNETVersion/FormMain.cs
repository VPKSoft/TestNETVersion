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

using System;
using System.Linq;
using System.Windows.Forms;

namespace TestNETVersion
{
    /// <summary>
    /// The main form of the application.
    /// Implements the <see cref="System.Windows.Forms.Form" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FormMain : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            cmbApplicationTypeSelection.Items.Add(NetApplicationType.AspNetCoreApp);
            cmbApplicationTypeSelection.Items.Add(NetApplicationType.NetCoreApp);
            cmbApplicationTypeSelection.Items.Add(NetApplicationType.AspNetCoreAll);
            cmbApplicationTypeSelection.Items.Add(NetApplicationType.WindowsDesktopApp);
        }

        private void cmbApplicationTypeSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            lbVersions.Items.Clear();
            lbMaximumVersionValue.Text = @"-";
            lbMinimumVersionValue.Text = @"-";
            var comboBox = (ComboBox) sender;
            if (comboBox.SelectedItem != null)
            {
                var versions = NetVersionCheck.GetAllVersions((NetApplicationType) comboBox.SelectedItem);

                lbMaximumVersionValue.Text = versions.Max()?.ToString();
                lbMinimumVersionValue.Text = versions.Min()?.ToString();

                foreach (var version in versions)
                {
                    lbVersions.Items.Add(version);
                }
            }
        }
    }
}
