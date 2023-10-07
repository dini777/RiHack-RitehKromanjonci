window.getLocation = function (dotnetHelper) {
    navigator.geolocation.getCurrentPosition(function (position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;

        dotnetHelper.invokeMethodAsync('OnLocationReceived', latitude, longitude);
    });
}