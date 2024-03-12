using Stupeni.FSA.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Stupeni.FSA.Permissions;

public class FSAPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FSAPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FSAPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FSAResource>(name);
    }
}
