internal static class MainClassHelpersHelpers
{
    public static bool Validation(Form F)
    {
        bool isValid = true;

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

        if (count > 0)
        {
            isValid = false;
        }

        return isValid;
    }
}
