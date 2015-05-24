/* Smooth scrolling effect */
$(function(){	

        var $window = $(window);
	var scrollTime = .5;
	var scrollDistance = 200;

	$window.on("mousewheel DOMMouseScroll", function(event){

		event.preventDefault();	

		var delta = event.originalEvent.wheelDelta/120 || -event.originalEvent.detail/3;
		var scrollTop = $window.scrollTop();
		var finalScroll = scrollTop - parseInt(delta*scrollDistance);

		TweenMax.to($window, scrollTime, {
			scrollTo : { y: finalScroll, autoKill:true },
				ease: Power1.easeOut,
				overwrite: 5							
			});

	});
});



/* Div appears on scrolling */
$(document).ready(function() {
    
    /* Every time the window is scrolled ... */
    $(window).scroll( function(){
    
        /* Check the location of each desired element */
        $('.hideme').each( function(){
            
            var top_of_object = $(this).position().top + $(this).outerHeight();
            var top_of_window = $(window).scrollTop() + $(window).height();
            
            /* If the object is completely visible in the window, fade it in */
            if( top_of_window > top_of_object ){
                
                $(this).animate({'opacity':'1'},500);
                    
            }
            
        }); 
    
    });
    
});



/* Carousel hover plugin */
 $(document).ready(function() {
    $('.carousel').carousel({interval: 7000});
  });
  
  

/* Portfolio hover plugin */
 $('document').ready(function(){
        
        //INITIALIZE THE PLUGIN
        $('#grid').mediaBoxes({
                showFilterBar: true, //Show the navigation filter bar at the top
                imagesToLoad: 5, //The number of images to load when you click the load more button
                imagesToLoadStart: 15, //The number of images to load when it first loads the grid
                lazyLoad: true, //If you wish to load more images when it reach the bottom of the page
                isFitWidth: true, //Nedded to be true if you wish to center the gallery to its container
                horizontalSpaceBetweenThumbnails: 15, //The space between images horizontally
                verticalSpaceBetweenThumbnails: 15, //The space between images vertically
                columnWidth: 'auto', //The width of each columns, if you set it to 'auto' it will use the columns instead
                columns: 5, //The number of columns when you set columnWidth to 'auto'
                columnMinWidth: 220, //The minimum width of each columns when you set columnWidth to 'auto'
                isAnimated: true, //If you wish the gallery to have animated effects when resizing the grid
                caption: true, //Show the caption in mouse over
                captionType: 'grid', // 'grid', 'grid-fade', 'classic' the type of caption effect
                hoverImageIconsAnimation: true, // The animation of the Icons of the image
                hoverImageIconsSpeedAnimation: 100, // The speed of the animation of the Icons of the image
                lightBox: true, //Do you want the lightbox?
                lightboxKeyboardNav: true, //Keyboard navigation of the next and prev image
                lightBoxSpeedFx: 500, //The speed of the lightbox effects
                lightBoxZoomAnim: true, //Do you want the zoom effect of the images in the lightbox?
                lightBoxText: true, //If you wish to show the text in the lightbox
                lightboxPlayBtn: true, //Show the play button?
                lightBoxAutoPlay: false, //The first time you open the lightbox it start playing the images
                lightBoxPlayInterval: 4000, //The interval in the auto play mode 
                lightBoxShowTimer: true, //If you wish to show the timer in auto play mode
                lightBoxStopPlayOnClose: false, //Do you want pause the auto play mode when you close the lightbox?
                allWord: "All", //The "All" word so you can translate it to another lenguaje
                loadMoreWord: "LOAD MORE ENTRIES", //The "Load More Entries" word so you can translate it to another lenguaje
        });

    });      