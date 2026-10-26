
using System.Threading.Tasks;
using Acme.Admin.Localization;
using Acme.Admin.Permissions;
using Acme.Admin.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;

namespace Acme.Admin.Web.Menus;

public class AdminMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(
        MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<AdminResource>();

        // HOME
        context.Menu.AddItem(new ApplicationMenuItem(
            AdminMenus.Home,
            l["Menu:Home"],
            url: "~/",
            icon: "fa fa-home",
            order: 1));

        //// NEWSPAPERS
        //context.Menu.AddItem(new ApplicationMenuItem(
        //    "Admin.Newspapers",
        //    l["Menu:Newspapers"],
        //    url: "/Newspapers",
        //    icon: "fa fa-newspaper",
        //    requiredPermissionName: AdminPermissions.Newspapers.Default));

        // =====================================================
        // 2.1 - 2.13 USER MANAGEMENT
        // =====================================================

        var users = AddTopLevelGroup(
            context.Menu, "Admin.UserManagement",
            "User Management", "fa fa-users");

        AddPage(users, "Activate Agents",
            "/UserManagement/ActivateAgents");
        AddPage(users, "Agent Information",
            "/UserManagement/AgentInformation");
        AddPage(users, "Reset Password",
            "/UserManagement/ResetPassword");
        AddPage(users, "User Management",
            "/UserManagement/Index");
        AddPage(users, "Activate Sub office User",
            "/UserManagement/ActivateSubOfficeUser");
        AddPage(users, "Create Sub Office BCCL",
            "/UserManagement/CreateSubOfficeBCCL");
        AddPage(users, "Sub Agent Information",
            "/UserManagement/SubAgentInformation");
        AddPage(users, "Transfer Agent to Sub office Agent",
            "/UserManagement/TransferAgentToSubOfficeAgent");
        AddPage(users, "Transfer Sub office Agent to Agent",
            "/UserManagement/TransferSubOfficeAgentToAgent");
        AddPage(users, "Lock Configuration",
            "/UserManagement/LockConfiguration");
        AddPage(users, "Un locking User Login",
            "/UserManagement/UnlockUserLogin");
        AddPage(users, "Block Agency for Desktop version",
            "/UserManagement/BlockAgencyDesktop");
        AddPage(users, "Agency logon detail and locking for web version",
            "/UserManagement/AgencyLogonDetails");

        // =====================================================
        // 2.14 - 2.90 MASTERS
        // =====================================================

        var masters = AddTopLevelGroup(
            context.Menu, "Admin.Masters",
            "Masters", "fa fa-database");

        AddPage(masters, "Ad Types", "/Masters/AdTypes");
        AddPage(masters, "BCC", "/Masters/BCC");
        AddPage(masters, "Parameters for TC.com",
            "/Masters/ParametersForTC");

        // Package
        var packages = AddGroup(
            masters, "Admin.Masters.Package",
            "Package", "fa fa-box");

        AddPage(packages, "TCC Wise", "/Masters/Package/TCCWise");
        AddPage(packages, "BCC Wise", "/Masters/Package/BCCWise");
        AddPage(packages, "Restrict Package Sales org wise",
            "/Masters/Package/RestrictSalesOrgWise");
        AddPage(packages, "Make Package Mandatory",
            "/Masters/Package/MakeMandatory");
        AddPage(packages, "Mandatory Package Exception",
            "/Masters/Package/MandatoryException");

        // Schemes
        var schemes = AddGroup(
            masters, "Admin.Masters.Schemes",
            "Schemes", "fa fa-tags");

        AddPage(schemes, "Free Scheme",
            "/Masters/Schemes/FreeScheme");
        AddPage(schemes, "Free Scheme in Set",
            "/Masters/Schemes/FreeSchemeInSet");
        AddPage(schemes, "Free Scheme on TCC with price group",
            "/Masters/Schemes/FreeSchemeTCCPriceGroup");
        AddPage(schemes, "Discounted Schemes",
            "/Masters/Schemes/DiscountedSchemes");
        AddPage(schemes, "Scheme Of package",
            "/Masters/Schemes/SchemeOfPackage");

        // Block Free Scheme
        var blockedSchemes = AddGroup(
            schemes, "Admin.Masters.Schemes.BlockFreeScheme",
            "Block Free Scheme", "fa fa-ban");

        AddPage(blockedSchemes, "Different BU Wise",
            "/Masters/Schemes/BlockFreeScheme/DifferentBUWise");
        AddPage(blockedSchemes, "TCC Wise",
            "/Masters/Schemes/BlockFreeScheme/TCCWise");
        AddPage(blockedSchemes, "BCC and PG Wise",
            "/Masters/Schemes/BlockFreeScheme/BCCAndPGWise");
        AddPage(blockedSchemes, "BU and PG Wise",
            "/Masters/Schemes/BlockFreeScheme/BUAndPGWise");

        AddPage(schemes, "Free Scheme Configuration",
            "/Masters/Schemes/FreeSchemeConfiguration");
        AddPage(schemes, "Manage Sap Code",
            "/Masters/Schemes/ManageSapCode");
        AddPage(schemes, "Free Scheme Scale Shifting",
            "/Masters/Schemes/FreeSchemeScaleShifting");

        // Other Masters
        AddPage(masters, "Priority", "/Masters/Priority");
        AddPage(masters, "Schedule", "/Masters/Schedule");
        AddPage(masters, "Consumption Deadlines",
            "/Masters/ConsumptionDeadlines");
        AddPage(masters, "Non Production Day",
            "/Masters/NonProductionDay");
        AddPage(masters, "Box No Range", "/Masters/BoxNoRange");
        AddPage(masters, "Background Color",
            "/Masters/BackgroundColor");
        AddPage(masters, "Dimensions", "/Masters/Dimensions");
        AddPage(masters, "Block OA", "/Masters/BlockOA");
        AddPage(masters, "BCCL Scheme", "/Masters/BCCLScheme");
        AddPage(masters, "Block Complete OA",
            "/Masters/BlockCompleteOA");

        // Promotion of Scheme
        var promotion = AddGroup(
            masters, "Admin.Masters.PromotionOfScheme",
            "Promotion of Scheme", "fa fa-bullhorn");

        AddPage(promotion, "Settings",
            "/Masters/PromotionOfScheme/Settings");
        AddPage(promotion, "Scheme",
            "/Masters/PromotionOfScheme/Scheme");

        // SMS
        var sms = AddGroup(
            masters, "Admin.Masters.SMS",
            "SMS", "fa fa-comment");

        AddPage(sms, "SMS Settings", "/Masters/SMS/Settings");
        AddPage(sms, "Expiry Days Detail",
            "/Masters/SMS/ExpiryDaysDetail");
        AddPage(sms, "SMS Mandatory - Order wise",
            "/Masters/SMS/MandatoryOrderWise");
        AddPage(sms, "SMS Mandatory - item wise",
            "/Masters/SMS/MandatoryItemWise");
        AddPage(sms, "Mandatory Exception by BCC",
            "/Masters/SMS/MandatoryExceptionByBCC");
        AddPage(sms, "Multiple SMS Settings",
            "/Masters/SMS/MultipleSMSSettings");
        AddPage(sms, "SMS Ad spec settings",
            "/Masters/SMS/AdSpecSettings");

        // Block Ad size/Color
        var adSizeColor = AddGroup(
            masters, "Admin.Masters.BlockAdSizeColor",
            "Block Ad size/Color", "fa fa-palette");

        AddPage(adSizeColor, "Block Ad Size",
            "/Masters/BlockAdSizeColor/BlockAdSize");
        AddPage(adSizeColor, "Block Color Ads",
            "/Masters/BlockAdSizeColor/BlockColorAds");
        AddPage(adSizeColor, "Global Block Ad Size",
            "/Masters/BlockAdSizeColor/GlobalBlockAdSize");
        AddPage(adSizeColor, "SQCM Allowed TCC List",
            "/Masters/BlockAdSizeColor/SQCMAllowedTCCList");

        // Iwish
        var iwish = AddGroup(
            masters, "Admin.Masters.Iwish",
            "Iwish", "fa fa-star");

        AddPage(iwish, "Iwish Popup length",
            "/Masters/Iwish/PopupLength");
        AddPage(iwish, "Iwish Mandatory",
            "/Masters/Iwish/Mandatory");
        AddPage(iwish, "Mandatory Exception by BCC",
            "/Masters/Iwish/MandatoryExceptionByBCC");
        AddPage(iwish, "Iwish Promotional Text",
            "/Masters/Iwish/PromotionalText");
        AddPage(iwish, "Iwish Sales org wise Mandatory",
            "/Masters/Iwish/SalesOrgWiseMandatory");
        AddPage(iwish, "Iwish Sales org wise Mandatory - 2",
            "/Masters/Iwish/SalesOrgWiseMandatory2");
        AddPage(iwish, "Iwish Lead", "/Masters/Iwish/Lead");
        AddPage(iwish, "Iwish Free Flag", "/Masters/Iwish/FreeFlag");

        AddPage(masters, "Read Document Settings",
            "/Masters/ReadDocumentSettings");

        // Capture Profile
        var profile = AddGroup(
            masters, "Admin.Masters.CaptureProfile",
            "Capture Profile", "fa fa-id-card");

        AddPage(profile, "Profile Capturing Rates",
            "/Masters/CaptureProfile/ProfileCapturingRates");
        AddPage(profile, "Profile Capturing Rates - 2",
            "/Masters/CaptureProfile/ProfileCapturingRates2");
        AddPage(profile, "Make Profile Capturing Mandatory Sales Org wise",
            "/Masters/CaptureProfile/MandatorySalesOrgWise");
        AddPage(profile, "Make Profile Capturing Mandatory",
            "/Masters/CaptureProfile/Mandatory");
        AddPage(profile, "Profile Capturing Tagline",
            "/Masters/CaptureProfile/Tagline");
        AddPage(profile, "Promotional Text for CIE",
            "/Masters/CaptureProfile/PromotionalTextForCIE");
        AddPage(profile, "Allow Profile Capturing",
            "/Masters/CaptureProfile/AllowProfileCapturing");
        AddPage(profile, "Allow Disallow Tagline",
            "/Masters/CaptureProfile/AllowDisallowTagline");
        AddPage(profile, "Allow TC Next Capturing Date",
            "/Masters/CaptureProfile/AllowTCNextCapturingDate");

        AddPage(masters, "Disallow Multiple Ad size",
            "/Masters/DisallowMultipleAdSize");
        AddPage(masters, "Restrict Advanced Booking",
            "/Masters/RestrictAdvancedBooking");
        AddPage(masters, "Setting for Upgrade service, Capture footer & Mobile service",
            "/Masters/UpgradeServiceSettings");
        AddPage(masters, "Allow Iwish Service",
            "/Masters/AllowIwishService");

        // Goa Ad type
        var goa = AddGroup(
            masters, "Admin.Masters.GoaAdType",
            "Goa Ad type", "fa fa-newspaper");

        AddPage(goa, "Include-Exclude Ad Types",
            "/Masters/GoaAdType/IncludeExcludeAdTypes");
        AddPage(goa, "New Ad Type Mapping",
            "/Masters/GoaAdType/NewAdTypeMapping");

        // Unicode Ads
        var unicode = AddGroup(
            masters, "Admin.Masters.UnicodeAds",
            "Unicode Ads", "fa fa-language");

        AddPage(unicode, "Allow Unicode Ads",
            "/Masters/UnicodeAds/AllowUnicodeAds");
        AddPage(unicode, "Manage Language Master",
            "/Masters/UnicodeAds/ManageLanguageMaster");

        AddPage(masters, "Manage Browser URL",
            "/Masters/ManageBrowserURL");
        AddPage(masters, "Manage DBS Port",
            "/Masters/ManageDBSPort");
        AddPage(masters, "BCC wise allowed BU",
            "/Masters/BCCWiseAllowedBU");
        AddPage(masters, "Prompt", "/Masters/Prompt");
        AddPage(masters, "Synonym Booking Units",
            "/Masters/SynonymBookingUnits");
        AddPage(masters, "Date Constraints for Parent Child Booking Unit",
            "/Masters/DateConstraintsParentChildBU");
        AddPage(masters, "Allow Dr Cr Publication Date Wise",
            "/Masters/AllowDrCrPublicationDateWise");

        // =====================================================
        // 2.91 - 2.97 UTILITY
        // =====================================================

        var utility = AddTopLevelGroup(
            context.Menu, "Admin.Utility",
            "Utility", "fa fa-wrench");

        AddPage(utility, "Alerts", "/Utility/Alerts");
        AddPage(utility, "Global Settings", "/Utility/GlobalSettings");
        AddPage(utility, "Update Master File", "/Utility/UpdateMasterFile");
        AddPage(utility, "Change Password", "/Utility/ChangePassword");
        AddPage(utility, "Configuration Settings",
            "/Utility/ConfigurationSettings");
        AddPage(utility, "Unlock order", "/Utility/UnlockOrder");
        AddPage(utility, "Unlock Astro-Speak", "/Utility/UnlockAstroSpeak");

        // =====================================================
        // 2.98 - 2.100 REPORTS
        // =====================================================

        var reports = AddTopLevelGroup(
            context.Menu, "Admin.Reports",
            "Reports", "fa fa-chart-bar");

        AddPage(reports, "All schemes", "/Reports/AllSchemes");
        AddPage(reports, "Schedule", "/Reports/Schedule");
        AddPage(reports, "BCCL Update", "/Reports/BCCLUpdate");

        // =====================================================
        // EXISTING ADMINISTRATION MENU
        // =====================================================

        var administration = context.Menu.GetAdministration();
        administration.Order = 6;

        administration.SetSubItemOrder(
            IdentityMenuNames.GroupName, 1);

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(
                TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(
                TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(
            SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }

    // Add a top-level group to the main application menu
    private static ApplicationMenuItem AddTopLevelGroup(
        ApplicationMenu menu,
        string name,
        string displayName,
        string icon)
    {
        var item = new ApplicationMenuItem(
            name,
            displayName,
            icon: icon);

        menu.AddItem(item);
        return item;
    }

    // Add a nested group under another menu item
    private static ApplicationMenuItem AddGroup(
        ApplicationMenuItem parent,
        string name,
        string displayName,
        string icon)
    {
        var item = new ApplicationMenuItem(
            name,
            displayName,
            icon: icon);

        parent.AddItem(item);
        return item;
    }

    // Add a page link under a menu item
    private static void AddPage(
        ApplicationMenuItem parent,
        string displayName,
        string url)
    {
        var name = $"Admin.Page.{url.Replace("/", ".").Trim('.')}";

        parent.AddItem(new ApplicationMenuItem(
            name,
            displayName,
            url: url));
    }
}
