(function($) {
    "use strict";
	 /* ==============================================
    Fixed menu
    =============================================== */
    
	$(window).on('scroll', function () {
		if ($(window).scrollTop() > 50) {
			$('.top-navbar').addClass('fixed-menu');
		} else {
			$('.top-navbar').removeClass('fixed-menu');
        }

	});
	
    /* ==============================================
       LOADER -->
    =============================================== */

    $(window).load(function() {
        $("#preloader").on(10).fadeOut();
        $(".preloader").on(10).fadeOut("slow");

    });


	/* ==============================================
		Scroll to top  
	============================================== */
		
	if ($('#scroll-to-top').length) {
		var scrollTrigger = 100, // px
			backToTop = function () {
				var scrollTop = $(window).scrollTop();
				if (scrollTop > scrollTrigger) {
					$('#scroll-to-top').addClass('show');
				} else {
					$('#scroll-to-top').removeClass('show');
				}
			};
		backToTop();
		$(window).on('scroll', function () {
			backToTop();
		});
		$('#scroll-to-top').on('click', function (e) {
			e.preventDefault();
			$('html,body').animate({
				scrollTop: 0
			}, 700);
		});
	}

    /* ==============================================
     FUN FACTS -->
     =============================================== */

    //function count($this) {
    //    var current = parseInt($this.html(), 10);
    //    current = current + 50; /* Where 50 is increment */
    //    $this.html(++current);
    //    if (current > $this.data('count')) {
    //        $this.html($this.data('count'));
    //    } else {
    //        setTimeout(function() {
    //            count($this)
    //        }, 30);
    //    }
    //}
    //$(".stat_count, .stat_count_download").each(function() {
    //    $(this).data('count', parseInt($(this).html(), 10));
    //    $(this).html('0');
    //    count($(this));
    //});
	
	/* ==============================================
     Full width Slider -->
     =============================================== */
	 
	$(document).ready(function() {
		var owl = $('#full-width');
		$('#full-width').owlCarousel({
			items: 1,
			loop:true,
			nav:true,
			margin: 0,
			navText: [
               "<i class='fa fa-angle-left effect-1'></i>",
               "<i class='fa fa-angle-right effect-1'></i>"
            ],
			autoplay:true,
			smartSpeed:500,
		});
		owl.on('changed.owl.carousel', function(event) {
			var item = event.item.index - 2;    
			$('h2').removeClass('animated zoomIn');
			$('p').removeClass('animated fadeInUp');
			$('.butn').removeClass('animated zoomIn');
			$('.owl-item').not('.cloned').eq(item).find('h2').addClass('animated zoomIn');			
			$('.owl-item').not('.cloned').eq(item).find('p').addClass('animated fadeInUp');
			$('.owl-item').not('.cloned').eq(item).find('.butn').addClass('animated zoomIn');
        });


	});

    /* ==============================================
     TOOLTIP -->
     =============================================== */
    $('[data-toggle="tooltip"]').tooltip()
    $('[data-toggle="popover"]').popover()

    /* ==============================================
     CODE WRAPPER -->
     =============================================== */

    $('.code-wrapper').on("mousemove", function(e) {
        var offsets = $(this).offset();
        var fullWidth = $(this).width();
        var mouseX = e.pageX - offsets.left;

        if (mouseX < 0) {
            mouseX = 0;
        } else if (mouseX > fullWidth) {
            mouseX = fullWidth
        }

        $(this).parent().find('.divider-bar').css({
            left: mouseX,
            transition: 'none'
        });
        $(this).find('.design-wrapper').css({
            transform: 'translateX(' + (mouseX) + 'px)',
            transition: 'none'
        });
        $(this).find('.design-image').css({
            transform: 'translateX(' + (-1 * mouseX) + 'px)',
            transition: 'none'
        });
    });
    $('.divider-wrapper').on("mouseleave", function() {
        $(this).parent().find('.divider-bar').css({
            left: '50%',
            transition: 'all .3s'
        });
        $(this).find('.design-wrapper').css({
            transform: 'translateX(50%)',
            transition: 'all .3s'
        });
        $(this).find('.design-image').css({
            transform: 'translateX(-50%)',
            transition: 'all .3s'
        });
    });

    /* ==============================================
     Reviewer -->
    =============================================== */
    //$.ajax({
        //    url: '/Home/Reviewer',
        //    type: "GET",
        //    contentType: "application/json;charset=utf-8",
        //    dataType: "json",
        //    success: function (data) {
        //        let containter = $('#list-testimonials .owl-stage');
        //        data.forEach(d => {
        //            let str =
        //                ` <div class="owl-item">
        //                    <div class="testimonial clearfix">
        //                        <div class="testi-meta">
        //                            <i class="fa fa-quote-right"></i>
        //                            <img src="../Uploads/testi_01.png" alt="" class="img-responsive alignright">
        //                            <h4>${d.Name} <small>- ${d.Job}</small></h4>
        //                        </div>
        //                        <div class="desc">
        //                            <h3>Wonderful Support!</h3>
        //                            <p class="lead">${d.Content}</p>
        //                        </div>
        //                    </div>
        //                   </div>
        //              `;
        //            $(str).appendTo(containter);
        //        });
        //        $('#list-testimonials').load(" #list-testimonials");


        //    },
        //    error: function (er) {
        //        console.log(er);
        //    }
        //});



})(jQuery);