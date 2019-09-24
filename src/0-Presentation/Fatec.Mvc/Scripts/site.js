navigator.serviceWorker.register('/service-worker.js', {
    scope: '/'
});

if ('serviceWorker' in navigator) {
    navigator.serviceWorker
        .register('/service-worker.js')
        .then(function (registration) {
            console.log('Registration successful, scope is:', registration.scope);
        })
        .catch(function (error) {
            console.log('Service worker registration failed, error:', error);
        });
}

function abrirLinkMenu(vUrl) {
    const elem = document.querySelector('#slide_menu');
    const instance = M.Sidenav.getInstance(elem);
    instance.close();
    window.location.href = vUrl;
};