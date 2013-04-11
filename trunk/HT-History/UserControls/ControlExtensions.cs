using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Translation;

namespace HtHistory.UserControls
{
    public static class ControlExtensions
    {
        public static void Translate(this Control control, ITranslator translator, bool recursive = true)
        {
            // Ok, here we go with an ugly convention:
            // If the name starts with "noTr_", the control is not going to be translated.
            // (This does not apply to all sub controls automatically)
            if (!control.Name.StartsWith("noTr_"))
            {
                string metaname = control.Name;

                Control parent = control.Parent;
                while (parent != null)
                {
                    metaname = string.Format("{0}.{1}", parent.Name, metaname);
                    parent = parent.Parent;
                }
                control.Text = translator.Translate(metaname);
            }

            if (recursive)
            {
                foreach (Control child in control.Controls)
                {
                    child.Translate(translator, recursive); // recursive should be "true" here, hehe.
                }
            }
        }

        public static void Translate(this ToolStripMenuItem item, ITranslator translator, bool recursive = true)
        {
            string metaname = item.Name;

            ToolStripItem parent = item.OwnerItem;
            while (parent != null)
            {
                metaname = string.Format("{0}.{1}", parent.Name, metaname);
                parent = parent.OwnerItem;
            }
            item.Text = translator.Translate(metaname);

            if (recursive)
            {
                foreach (object subobj in item.DropDownItems)
                {
                    ToolStripMenuItem subitem = subobj as ToolStripMenuItem;
                    if (subitem != null) subitem.Translate(translator, recursive);
                }
            }

        }

        public static void Translate(this ToolStrip strip, ITranslator translator, bool recursive = true)
        {
            Control control = strip;
            control.Translate(translator, recursive);

            if (recursive)
            {
                foreach (object subobj in strip.Items)
                {
                    ToolStripMenuItem subitem = subobj as ToolStripMenuItem;
                    if (subitem != null) subitem.Translate(translator, recursive);
                }
            }
        }
    }
}
