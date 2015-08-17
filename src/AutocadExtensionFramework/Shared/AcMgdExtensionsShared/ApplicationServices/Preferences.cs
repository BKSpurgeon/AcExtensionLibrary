using Autodesk.AutoCAD.ApplicationServices.PreferencesDisplay;
using Autodesk.AutoCAD.ApplicationServices.PreferencesFiles;
using Autodesk.AutoCAD.ApplicationServices.PreferencesUser;

namespace Autodesk.AutoCAD.ApplicationServices
{
    public static class Preferences
    {
        static dynamic AcadPreferences { get { return Application.Preferences; } }

        public static SupportPath SupportPaths { get { return new SupportPath(AcadPreferences); } }
        public static ToolPalettePath ToolPalettePaths { get { return new ToolPalettePath(AcadPreferences); } }
        public static PrinterConfigPath PrinterConfigPath { get { return new PrinterConfigPath(AcadPreferences); } }
        public static PrinterDescPath PrinterDescPath { get { return new PrinterDescPath(AcadPreferences); } }
        public static PrinterStyleSheetPath PrinterStyleSheetPath { get { return new PrinterStyleSheetPath(AcadPreferences); } }
        public static TemplateDWGPath TemplateDWGPath { get { return new TemplateDWGPath(AcadPreferences); } }

        public static EnterpriseMenuFile EnterpriseMenuFile { get { return new EnterpriseMenuFile(AcadPreferences); } }
        public static MenuFile MenuFile { get { return new MenuFile(AcadPreferences); } }
        public static DisplayScrollBars DisplayScrollBars { get { return new DisplayScrollBars(AcadPreferences); } }
        public static SCMTimeValue SCMTimeValue { get { return new SCMTimeValue(AcadPreferences); } }
        public static PageSetupOverridesTemplateFile PageSetupOverridesTemplateFile { get { return new PageSetupOverridesTemplateFile(AcadPreferences); } }
        public static QNewTemplateFile QNewTemplateFile { get { return new QNewTemplateFile(AcadPreferences); } }
    }
}
