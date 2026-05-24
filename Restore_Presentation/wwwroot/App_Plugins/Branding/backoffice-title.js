
export function changeTitle(title) {
    return title.replace(/Umbraco/g, 'Restaurering CMS');
}

export function titleInterceptor() {
    let titleDescriptor =
        Object.getOwnPropertyDescriptor(Document.prototype, 'title') ||
        Object.getOwnPropertyDescriptor(document, 'title');

    if (!titleDescriptor) return;

    Object.defineProperty(document, 'title', {
        set: function (newTitle) {
            const modifiedTitle = changeTitle(newTitle);
            titleDescriptor.set.call(this, modifiedTitle);
        },
        get: function () {
            return titleDescriptor.get.call(this);
        },
        configurable: true
    });

    if (document.title.includes('Umbraco')) {
        document.title = changeTitle(document.title);
    }
}

titleInterceptor();