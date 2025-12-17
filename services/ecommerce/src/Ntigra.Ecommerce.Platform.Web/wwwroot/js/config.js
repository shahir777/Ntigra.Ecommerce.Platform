(function () {
    const html = document.documentElement;
    const storageKey = "__CONFIG__";

    // Force DARK MODE configuration
    const darkConfig = {
        skin: "default",
        monochrome: false,
        theme: "dark",
        layout: {
            position: "fixed",
        },
        topbar: {
            color: "dark",
        },
        menu: {
            color: "dark",
        },
        sidenav: {
            size: "default",
            user: false,
        },
    };

    // Save once (optional but recommended)
    sessionStorage.setItem(storageKey, JSON.stringify(darkConfig));

    // Expose globally (optional)
    window.config = darkConfig;
    window.defaultConfig = structuredClone(darkConfig);

    // Apply dark mode immediately
    html.setAttribute("data-skin", darkConfig.skin);
    html.setAttribute("data-bs-theme", "dark");
    html.setAttribute("data-menu-color", "dark");
    html.setAttribute("data-topbar-color", "dark");
    html.setAttribute("data-layout-position", darkConfig.layout.position);
    html.classList.remove("monochrome");

    // Handle sidenav sizing
    let size = darkConfig.sidenav.size;

    if (window.innerWidth <= 767) {
        size = "offcanvas";
    } else if (window.innerWidth <= 1140) {
        size = "condensed";
    }

    html.setAttribute("data-sidenav-size", size);

})();
