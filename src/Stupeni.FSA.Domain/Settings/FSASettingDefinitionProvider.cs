using Volo.Abp.Settings;

namespace Stupeni.FSA.Settings;

public class FSASettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FSASettings.MySetting1));
    }
}
