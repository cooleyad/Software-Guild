$(document).ready(function () {
	$("H1").css({ "text-align": "center" })
	$("H2").css({ "text-align": "center" })
	$('.myBannerHeading').removeClass('myBannerHeading').addClass('page-header');

	$('#yellowHeading').append('h2').text('Yellow Team');
	$('#orangeTeamList').css('background-color', 'orange');
	$('#blueTeamList').css('background-color', 'blue');
	$('#redTeamList').css('background-color', 'red');
	$('#yellowTeamList').css('background-color', 'yellow').append('<li>Joseph Banks</li>').append('<li>Simon Jones</li>');


	$('#oops').hide();

	$('#footerPlaceholder').remove();

	$('#footer').append('p').text('Whalen Jonesface  Jonesface@jonesface.com').css('font-family', 'Courier', 'font-size', '24px');
});