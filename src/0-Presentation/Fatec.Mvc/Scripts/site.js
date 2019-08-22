if ('serviceWorker' in navigator) {
    navigator.serviceWorker.register('/Scripts/service-worker.js')
        .then(function (registration) {
            console.log('Registration successful, scope is:', registration.scope);
        })
        .catch(function (error) {
            console.log('Service worker registration failed, error:', error);
        });
}

navigator.serviceWorker.register('/Views/service-worker.js', {
    scope: '/Home'
});