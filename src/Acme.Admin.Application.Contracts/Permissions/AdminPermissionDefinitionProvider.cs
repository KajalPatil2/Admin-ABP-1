using Acme.Admin.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acme.Admin.Permissions;

public class AdminPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AdminPermissions.GroupName);
        var booksPermission = myGroup.AddPermission(AdminPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AdminPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AdminPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AdminPermissions.Books.Delete, L("Permission:Books.Delete"));
        var newspapersPermission = myGroup.AddPermission(AdminPermissions.Newspapers.Default, L("Permission:Newspapers"));
        newspapersPermission.AddChild(AdminPermissions.Newspapers.Create, L("Permission:Newspapers.Create"));
        newspapersPermission.AddChild(AdminPermissions.Newspapers.Edit, L("Permission:Newspapers.Edit"));
        newspapersPermission.AddChild(AdminPermissions.Newspapers.Delete, L("Permission:Newspapers.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AdminPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AdminResource>(name);
    }
}
