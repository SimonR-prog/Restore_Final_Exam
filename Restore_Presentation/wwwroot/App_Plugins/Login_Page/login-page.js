
// Creating stylesheet.
export function createStyleSheetLink(href) {
    if (!href || href.trim() === "") {
        return null;
    }

    const link = document.createElement("link");
    link.rel = "stylesheet";
    link.href = href;

    return link;
}

// Adding the stylesheet
export function addLoginStyleSheet() {
    const cssPath = '/App_Plugins/Login_Page/login-page.css';

    const link = createStyleSheetLink(cssPath);
    if (link === null) {
        console.warn("Failed to create stylesheet link: invalid href");
        return;
    }

    document.head.appendChild(link)
}

// Initialize
addLoginStyleSheet();