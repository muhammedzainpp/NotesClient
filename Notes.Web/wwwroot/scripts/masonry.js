export function initOptionsForLayout() {

    setTimeout(function () {
        var msnry = new Masonry('.row', {
            itemSelector: '.col',
            percentPosition: true
        });
        msnry.layout();
    }, 3000);
}