using PluginInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class PluginsForm : Form
    {
        private readonly PluginConfig config;
        private readonly string configPath;
        private readonly Dictionary<string, IPlugin> allPlugins;

        public PluginsForm(PluginConfig config, string configPath, Dictionary<string, IPlugin> allPlugins)
        {
            InitializeComponent();
            this.config = config;
            this.configPath = configPath;
            this.allPlugins = allPlugins;
            InitializePluginsList();
        }

        private void InitializePluginsList()
        {
            pluginsDataGridView.Rows.Clear();

            foreach (var plugin in allPlugins.Values)
            {
                var version = "1.0";
                var versionAttr = (VersionAttribute)Attribute.GetCustomAttribute(
                    plugin.GetType(), typeof(VersionAttribute));
                if (versionAttr != null)
                {
                    version = $"{versionAttr.Major}.{versionAttr.Minor}";
                }

                bool enabled = config.AutoLoad ||
                    config.Plugins.Exists(p => p.Name == plugin.Name && p.Enabled);

                pluginsDataGridView.Rows.Add(
                    enabled,
                    plugin.Name,
                    plugin.Author,
                    version
                );
            }

            autoLoadCheckBox.Checked = config.AutoLoad;
            autoLoadCheckBox_CheckedChanged(null, null);
        }

        private void autoLoadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pluginsDataGridView.Enabled = !autoLoadCheckBox.Checked;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            config.AutoLoad = autoLoadCheckBox.Checked;

            if (!config.AutoLoad)
            {
                config.Plugins.Clear();
                foreach (DataGridViewRow row in pluginsDataGridView.Rows)
                {
                    if (row.Cells[0].Value is bool enabled)
                    {
                        config.Plugins.Add(new PluginInfo
                        {
                            Name = row.Cells[1].Value.ToString(),
                            Author = row.Cells[2].Value.ToString(),
                            Version = row.Cells[3].Value.ToString(),
                            Enabled = enabled
                        });
                    }
                }
            }

            config.Save(configPath);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
