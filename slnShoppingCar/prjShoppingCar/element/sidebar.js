$(document).ready(function () {
  $("#sidebar").mCustomScrollbar({
    theme: "minimal"
  });

  $('#dismiss, .overlay').on('click', function () {
    $('#sidebar').removeClass('active');
    $('.overlay').fadeOut();
  });

  $('#sidebarCollapse').on('click', function () {
    $('#sidebar').addClass('active');
    $('.overlay').fadeIn();
    $('.collapse.in').toggleClass('in');
    $('a[aria-expanded=true]').attr('aria-expanded', 'false');
  });
});

//    $(window).resize(function () {
//        if (> min_width) {
//            $("#sidebarCollapse").show()
//        } else {
//            $("#toplist").hide()
//        }
//    });
//})
