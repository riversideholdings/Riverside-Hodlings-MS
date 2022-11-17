$(document).ready(function () {
    console.log("ready!");
    $('#sidebar').toggleClass('active');
});

$('#sidebar').toggleClass('active');
(function ($) {
    "use strict"; var fullHeight = function () {
        $('.js-fullheight').css('height',
            $(window).height()); $(window).resize(function () {
                $('.js-fullheight').css('height',
                    $(window).height());
            });
    }; fullHeight();
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });
})(jQuery);