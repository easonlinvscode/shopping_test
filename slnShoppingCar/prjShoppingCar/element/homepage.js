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
$(function () {
  $(window).scroll(function () {
    if ($(this).scrollTop() > 50) {          /* 要滑動到選單的距離 */
      $('.dropdowns').addClass('navFixed');   /* 幫選單加上固定效果 */
    } else {
      $('.dropdowns').removeClass('navFixed'); /* 移除選單固定效果 */
    }
  });
});
// JavaScript Document

$(function () {

  $("#top").click(function () {

    $("html,body").animate({ scrollTop: 0 }, 900);

    //$("html,body").animate({scrollTop:0},900,"easeOutBounce");

    return false;

  });

});
$(function () {
  $(window).load(function () {
    $(window).bind('scroll resize', function () {
      var $this = $(this);
      var $this_Top = $this.scrollTop();

      //當高度小於100時，關閉區塊 
      if ($this_Top < 170) {
        $('#top').stop().animate({ bottom: "-580px" });
      }
      if ($this_Top > 170) {
        $('#top').stop().animate({ bottom: "10px" });
      }
    }).scroll();
  });
});
$(function () {
  $(window).load(function () {
    $(window).bind('scroll resize', function () {
      var $this = $(this);
      var $this_Top = $this.scrollTop();

      //當高度小於100時，關閉區塊 
      if ($this_Top < 170) {
        $('#top-bar').stop().animate({ top: "-65px" });
      }
      if ($this_Top > 170) {
        $('#top-bar').stop().animate({ top: "0px" });
      }
    }).scroll();
  });
});