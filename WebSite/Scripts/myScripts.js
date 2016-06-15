$(document).ready(function () {
    var pathname = (window.location.pathname.substr(1) == '') ? 'Home' : window.location.pathname.substr(1);
    var item = '.menuItem ' + '.' + pathname;
    console.debug(item);
    $(item).css({
        'font-size': 'larger',
        'background-color': 'rgba(132, 200, 248, 0.40)'
    });
});