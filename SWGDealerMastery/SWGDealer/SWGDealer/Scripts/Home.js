$(document).ready(function () {

	loadFeatured();
	specialsShown();

	function loadFeatured() {

		$.ajax({
			type: 'GET',
			url: 'http://localhost:53012/featured',
			success: function (results) {

				$.each(results, function (index, vehicle) {

					var row = "";
					var year = vehicle.year;
					var make = vehicle.vehicleModel.vehicleMake.make;
					var model = vehicle.vehicleModel.model;
					var image = vehicle.image;
					var price = vehicle.salePrice;

					row = '<div class="col-xs-3" style=text-align :center; display="overflow:hidden";">< img src= "' + image + '" height= "100%" width="100%" style="border:2px solid black;">'
					row += '<h6>' + year + ' ' + make + ' ' + model 
					row += '</h6><p>Sale Price: $' + price + '</p></h5></div>'

					$('#featured').append(row);
					});
			},
			error: function (jpXHR, textStatus, errorThrown) { }
		});
		

	}

	function specialsShown() {

		$.ajax({
			type: 'GET',
			url: 'http://localhost:53012/specials',
			success: function (result) {
				$('#specialsShown').empty();

				$.each(result, function(index, salesSpecials){

					var title= salesSpecials.specialsName;
					var desc = salesSpecials.specialDesc;

					var row = '<div class="row" style=text-align :center; display="overflow:hidden";style="border:2px solid black; margin-bottom:10px"><h4>' + title +'</h4>' + '</hr>';
					row += '<p>' + desc + '<p>' + '</div>';
					$('#specialsShown').append(row);
				})


			},
			error: function () { }
		});
	}

});