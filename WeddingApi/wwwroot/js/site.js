

//login page
jQuery(document).ready(function ($) {
	tab = $('.tabs h5 a');

	tab.on('click', function (event) {
		event.preventDefault();
		tab.removeClass('active');
		$(this).addClass('active');

		tab_content = $(this).attr('href');
		$('div[id$="tab-content"]').removeClass('active');
		$(tab_content).addClass('active');
	});
});

//dashboard sidebar menu
$(document).ready(function () {
	$('#sidebarCollapse').on('click', function () {
		$('#sidebar').toggleClass('active');
	});
});

