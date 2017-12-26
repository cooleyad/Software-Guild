$(document).ready(function () {
	$('#searchResults').hide();
	$('#details').hide();

});

function newSearch() {
	$('#searchResults').show();
	search('new');

}

function usedSearch() {
	$('#searchResults').show();
	search('used');
}

function search(type) {
	var searchKey = $('#searchKey').val();
	var minYear = $('#minYear').val();
	var maxYear = $('#maxYear').val();
	var minPrice = $('#minPrice').val();
	var maxPrice = $('#maxPrice').val();

	$.ajax({
		url: 'http://localhost:53012/vehicle/' + type + '/' + searchKey + '/' + minYear + '/' + maxYear + '/' + minPrice + '/' + maxPrice,
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

				row = '<div class = "col-xs-6" style="text-align:center; display= "overflow:hidden";"><img src="' + image + '" height="100%" width="100%" style ="border:2px solid black;">'
				row += '<div class="col-xs-6"><table style= "width:100%">'
				row += '<tr><td> Body Style: ' + style + '</td><td> Interior Color:' + intColor
				row += '</td><td> Sale Price:' + salePrice + '</td></tr>'
				row += '<tr><td> Transmission: ' + transmission + '</td><td> Mileage:' + mileage
				row += '</td><td> MSRP:' + msrp + '</td></tr>'
				row += '<tr><td> Exterior Color: ' + extColor + '</td><td> VIN:' + vin + '</td><td><button type="submit" class="btn btn-primary" onclick="details(' + id + ')">Details</button></a></td></tr></table></div></div>'

				$('#searchResults').append(row);
			});
		},
		error: function () {

		}
	});
}

function details(id) {
	$('#searchZone').hide();
	$('#searchResults').hide();
	$('#details').show();

	$.ajax({
		url: 'http://localhost:53012/vehicle/' + id,
		type: 'GET',

		success: function (result) {
			//$('#details').empty();

			//$.each(results, function (index, vehicle) {

			//var row = "";
			//var style = vehicle.bodyStyle;
			//var transmission = vehicle.transmissionType;
			//var extColor = vehicle.color;
			//var intColor = vehicle.interiorColor;
			//var model = vehicle.model.vehicleModelName;
			//var make = vehicle.model.make.vehicleMakeName;
			//var mileage = vehicle.odometer;
			//var year = vehicle.year;
			//var salePrice = vehicle.salePrice;
			//var msrp = vehicle.msrp;
			//var image = vehicle.image;
			//var vin = vehicle.vin;
			//var description = vehicle.description;
			//var id = vehicle.vehicleId;

			row = '<div class = "col-md-9" style="text-align:center; display= "overflow:hidden";"><img src="' + result.image + '" height="100%" width="100%" style ="border:2px solid black;">'
			row += '<div class="col-md-9"><table style= "width:100%">'
			row += '<tr><td> Body Style: ' + result.bodyStyle + '</td><td> Interior Color:' + result.interiorColor +' </td > <td> Sale Price:' + result.salePrice + '</td></tr >'
			row += '<tr><td> Transmission: ' + result.transmissionType + '</td><td> Mileage:' + result.odometer + '</td><td> MSRP:' + result.msrp + '</td></tr>'
			row += '<tr><td> Exterior Color: ' + result.color + '</td><td> VIN:' + result.vin + '</td>'
			row += '<tr><td>Description: ' + result.description + '</td></tr>'
			row += '<td><button type="submit" class="btn btn-primary" ><a href="Contact/' + result.vin + '">Contact Us</button></a></td></tr ></table ></div ></div >'

			$('#details').append(row);
		}
	});
}
