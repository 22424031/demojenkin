using acme.Bookstore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace acme.Bookstore.Permissions;

public class BookstorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var BookStoreGroup = context.AddGroup(BookstorePermissions.GroupName, L("Permission:BookStore"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookstorePermissions.MyPermission1, L("Permission:MyPermission1"));
        var BooksPermission = BookStoreGroup.AddPermission(BookstorePermissions.Books.Default, L("Permission:Books"));
        BooksPermission.AddChild(BookstorePermissions.Books.Create, L("Permission.Books.Create"));
        BooksPermission.AddChild(BookstorePermissions.Books.Edit, L("Permission.Books.Edit"));
        BooksPermission.AddChild(BookstorePermissions.Books.Delete, L("Permission.Books.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookstoreResource>(name);
    }
}
