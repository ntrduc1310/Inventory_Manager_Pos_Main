using Microsoft.Data.SqlClient;
using PL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

internal static class MainClassHelpers
{
    public static bool Validation(Form F)
    {
        bool isValid = false;
        int count = 0;

        foreach (Control c in F.Controls)
        {
            if (Convert.ToString(c.Tag) != "" && Convert.ToString(c.Tag) != null)
            {
                if (c is Guna.UI2.WinForms.Guna2TextBox)
                {
                    Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                    if (t.Text.Trim() == "")
                    {
                        t.BorderColor = Color.Red;
                        t.FocusedState.BorderColor = Color.Red;
                        t.HoverState.BorderColor = Color.Red;
                        count++;
                    }
                    else
                    {
                        t.BorderColor = Color.FromArgb(213, 128, 223);
                        t.FocusedState.BorderColor = Color.FromArgb(95, 71, 204);
                        t.HoverState.BorderColor = Color.FromArgb(95, 71, 204);
                    }
                }
            }
        }

        isValid = count == 0;
        return isValid;
    }

}