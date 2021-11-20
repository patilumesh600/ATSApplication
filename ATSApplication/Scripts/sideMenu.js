function menuItemActive(mainMenuItemId, clickItemId) {
    $('.nav-link').removeClass("active");
    $('.nav-item').removeClass("menu-is-opening").removeClass("menu-open");
    $('.nav-treeview').css("display", "none");
    $('#' + mainMenuItemId + ' .nav-treeview').css("display", "block");
    $('#' + mainMenuItemId + ' a').first().addClass("active");
    $('#' + mainMenuItemId).addClass("menu-is-opening");
    $('#' + clickItemId + ' .nav-link').addClass("active");
}