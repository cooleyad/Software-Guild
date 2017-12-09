$(document).ready(function () {
	loadMake();
	loadModel();

	function loadMake() {
		$.ajax({
			type: 'GET',
			url: 'http://localhost:53012/makes',
			success: function (results) {
				$.each(results, function (index, make) {
					var row = "";

					row += '<div class ="row">'
					row +='<div class="col-md-12">'
					row += '<table class= "table table-bordered table-striped"><tr><th>Make</th><th>Added</th><th>User</th></tr>'
					row += '<tbody><tr><td>' + make.vehicleMakeName + '</td>'
					row += '<td>' + make.dateAdded + '</td>'
					row += '<td>' + make.appUser + '</td>'
					row += '</tr></tbody></table>'
					row+='</div>'
					$('#makeDetails').append(row);
				});
			},
			error: function (jpXHR, textStatus, errorThrown) { }
		});

	}

	function loadModel() {
		$.ajax({
			type: 'GET',
			url: 'http://localhost:53012/models',
			success: function (results) {
				$.each(results, function (index, model){
					var row = "";

					row += '<table class= "table table-bordered table-striped"><thead><tr><th>Make</th><th>Added</th><th>User</th></tr></thead>'
					row +='<tbody>'
					row += '<tr><td> ' + model.vehicleModelName + '</td>'
					row += '<td>' + model.vehicleMakeName + '</td>'
					row += '<td>' + model.dateAdded + '</td>'
					row += '<td>' + model.appuser + '</td>'
					row += '</tr></tbody></table>'

					$('#modelDetails').append(row);
				});
			},
			error: function (jpXHR, textStatus, errorThrown) { }
		});
	}
});