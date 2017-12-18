$(document).ready(function () {
	$('#searchResults').hide();

});

function showCars() {
	$('#searchResults').show();
	search();
}

function search() {
	var searchKey = $('#searchKey').val();
	var minYear = $('#minYear').val();
	var maxYear = $('#maxYear').val();
	var minPrice = $('#minPrice').val();
	var maxPrice = $('#maxPrice').val();

	$.ajax({
		url: 'http://localhost:53012/vehicle/both/' + searchKey + '/' + minYear + '/' + maxYear + '/' + minPrice + '/' + maxPrice,
		type: 'GET',

		success: function (results) {
			$('#searchResults').empty();

			$.each(results, function (index, vehicle) {

				var row = "";
				var style = vehicle.bodyStyle;
				var transmission = vehicle.transmissionType;
				var extColor = vehicle.color;
				var intColor = vehicle.interiorColor;
				var model = vehicle.model.vehicleModelName;
				var make = vehicle.model.make.vehicleMakeName;
				var mileage = vehicle.odometer;
				var year = vehicle.year;
				var salePrice = vehicle.salePrice;
				var msrp = vehicle.msrp;
				var image = vehicle.image;
				var vin = vehicle.vin;
				var description = vehicle.description;
				var id = vehicle.vehicleId;

				row = '<div class = "col-xs-4" style="text-align:center; display= "overflow:hidden";"><img src="' + image + '" height="100%" width="100%" style ="border:2px solid black;">'
				row += '<div class="col-xs-9"><table style= "width:75%">'
				row += '<tr><td> Body Style: ' + style + '</td><td> Interior Color:' + intColor 
				row += '</td><td> Sale Price:' + salePrice + '</td></tr>'
				row += '<tr><td> Transmission: ' + transmission + '</td><td> Mileage:' + mileage
				row += '</td><td> MSRP:' + msrp + '</td></tr>'
				row += '<tr><td> Exterior Color: ' + extColor + '</td><td> VIN:' + vin + '</td><td><a href="/Admin/Edit/' + id + '"><button type="submit" class="btn btn-primary">Edit</button></a></td></tr></table></div></div>'


				$('#searchResults').append(row);
			});
		},
		error: function () {

		}

	});
}