
$(document).ready(function () {

  var count = 0;

  $('.menu-toggle').click(function(){
    count += 1;
    if(count % 2 == 0){
      $('.main_menu .menu_mobile').removeClass('show');
      TweenMax.killAll('.menu_mobile li');
    }else{
      $('.main_menu .menu_mobile').addClass('show');
      TweenMax.staggerFrom(".menu_mobile li",0.5,{x:-100,opacity: 0,ease:Cubic.easeInOut},0.15);
    }
  });

  // back to top
  // if($(window).width()>1024){
    if($("#back-to-top").length > 0)
    {
      $(window).scroll(function () 
      {
        var e = $(window).scrollTop();
        if (e > 1) 
        {
          $("#back-to-top").show()
        } 
        else
        {
          $("#back-to-top").hide()
        }
      });
      $("#back-to-top").click(function (){
        $('body,html').animate({scrollTop: 0},1500)
      })
    }
  // }

  $('#fullpage').fullpage({
    css3:true,
    easing:'easeOutQuart', 
    easingcss3:'ease',
    scrollingSpeed: 750,
    responsiveWidth:1024,
    normalScrollElements:'.list_news',
    scrollBar:true,
    onLeave: function(origin, destination, direction){
      let i = destination.index;
      $(`.menu ul li`).removeClass("active");
      $(`.menu ul li:nth-child(${i + 1})`).addClass("active")
    }
  });

  
  $('.product_slide').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    arrows: true,
    dots: false,
    centerMode: true,
    variableWidth: true,
    infinite: true,
    // focusOnSelect: true,
    autoplay:false,
    cssEase: 'linear',
    prevArrow:' <i class="fa fa-angle-left"></i>',
    nextArrow:' <i class="fa fa-angle-right"></i>',
    responsive:[{
      breakpoint: 568,
      settings:{
        centerMode:false,
        variableWidth:false,
        fade:true,
        slidesToShow:1,
        slidesToScroll:1
      }
    }]
  });

  $('.shophouse_slide').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: true,
    fade: true,
    dots: false,
    infinite: true,
    autoplay:false,
    cssEase: 'linear',
    prevArrow:' <i class="fa fa-angle-left"></i>',
    nextArrow:' <i class="fa fa-angle-right"></i>',
    responsive:[{
      breakpoint: 568,
      settings:{
        slidesToShow:1,
        slidesToScroll:1
      }
    }]
  });

  $('.wyndham_slide').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    fade: true,
    arrows: true,
    dots: false,
    infinite: true,
    autoplay:false,
    cssEase: 'linear',
    prevArrow:' <i class="fa fa-angle-left"></i>',
    nextArrow:' <i class="fa fa-angle-right"></i>',
    responsive:[{
      breakpoint: 568,
      settings:{
        slidesToShow:1,
        slidesToScroll:1
      }
    }]
  });

  $('.utilities_slide').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    arrows: true,
    dots: false,
    centerMode: true,
    variableWidth: true,
    infinite: true,
    // focusOnSelect: true,
    autoplay:false,
    cssEase: 'linear',
    prevArrow:' <i class="fa fa-angle-left"></i>',
    nextArrow:' <i class="fa fa-angle-right"></i>',
    responsive:[{
      breakpoint: 568,
      settings:{
        centerMode:false,
        variableWidth:false,
        fade:true,
        slidesToShow:1,
        slidesToScroll:1
      }
    }]
  });

  $('.hotline').click(function(){
    count += 1;
    if($(window).width() > 1024){

      if(count % 2 == 0){
        $(this).css('transform','translateX(235px)')
      }else{
        $(this).css('transform','translateX(0)')
      }

    }else{

      if(count % 2 == 0){
        $(this).css('transform','translateX(240px)')
      }else{
        $(this).css('transform','translateX(0)')
      }
    }

  });

  $('.edit').click(function(){
    $('.register').css('transform','translateX(0)')
    $(this).css('transform','translateX(46px)')
  });
  $('.close').click(function(){
    $('.register').css('transform','translateX(290px)')
    $('.edit').css('transform','translateX(0)')
  });


  TweenMax.staggerFrom(".menu ul li",0.5,{y:-100,opacity: 0,ease: Back.easeOut},0.2);
  
  $('.menu ul li a').click(function () {
    var id = $(this).data('id');
    fullpage_api.moveTo(id);
  });

  var del = $('#slide').height();
  $('.slide_images a').css('height',del+'px');

  $(window).scroll(function(){
    var scroll = $(window).scrollTop();
    if(scroll >= 623){
      $('.header').css('background','rgba(183,191,173,1)')
      $('.logo a .logo1').css('display','none');
      $('.logo a .logo2').css('display','block');
    }else{
      $('.header').css('background','rgba(0,98,46,0.5)')
      $('.logo a .logo1').css('display','block');
      $('.logo a .logo2').css('display','none');
    }
  });

  // $(window).scroll(function(){
  //   var scroll = $(window).scrollTop();
  //   var e = $('#news').offset().top;
  //   console.log(scroll);
  //   console.log(e);
  //   if(scroll == e){
  //     TweenMax.staggerFrom(".list_news ul li",0.4,{scale:0.2,opacity:0},0.2);
  //   }else{
  //     TweenMax.killAll('.list_news ul li');
  //   }
  // });

});

