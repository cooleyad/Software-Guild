var total=0;
$(document).ready(function () {
	loadProducts();
	addMoney();
	getChange();

});
$('#loadStuff').on('click', '.items', function () {
	var itemId = $(this).data("id");
	$('#item').val(itemId);
});

function loadProducts() {
	$.ajax({
		type: 'GET',
		url: 'http://localhost:8080/items',
		success: function (itemLoad) {
			var itemsPlace = $('#loadStuff');
			itemsPlace.empty();
			$.each(itemLoad, function (index, product) {
				var itemDisplays=$('#product' + product.id);

				var item = this.id;
				var name = this.name;
				var price = this.price;
				var quantity = this.quantity;

				var row = '<div class="col-md-4 items" data-id=" ' + product.id + '">';
				row += '<p>' + item + '</p>';
				row += '<p>' + name + '</p>';
				row += '<p>' + '$' + cost.toFixed(2) + '</p>';
				row += '<p>' + 'Quantity Remaining: ' + quantity + '</p>' + '</div>';

				itemsPlace.append(row);
			});
		},
		error: function () {
		}
	})
}
function addMoney() {
	var dollar = 1.00;
	var quarter = .25;
	var dime = .10;
	var nickel = .05;	


	$('#addDollar').click( function () {
		total = total + dollar;
		$('#totalAdded').val(total,toFixed(2));
	})
	$('#addQuarter').click( function () {
		total = total + quarter;
		$('#totalAdded').val(total,toFixed(2));
	})
	$('#addDime').click( function () {
		total = total + dime;
		$('#totalAdded').val(total,toFixed(2));
	})
	$('#addNickel').click( function () {
		total = total + nickel;
		$('#totalAdded').val(total,toFixed(2));
	})
}
$('#purchaseButton').click(function () {
	var total = $('#moneyDisplay').val();
	var itemId = $('#item')

	if (itemId == "") {
		$('#displayMessage').val('Please make a selection.')
	}
	else if (total == "") {
		$('#displayMessage').val('Show me the money.');
	}
	else {
		$.ajax({
			type: 'GET',
			url: 'http://localhost:8080/money/' + total + '/item/' + selectedItemId,
			success: function (change) {
				$('#displayMessage').val("Thank you for your purchase.");

				var quarters = change.quarters
				var dimes = change.dimes
				var nickels = change.nickels

				var returnChange = 'Quarter(s): ' + quarters + 'Dime(s): ' + dimes + 'Nickel(s): ' + nickels;
				loadProducts();

				total = 0;
				$('#cashDisplay').val('');

				$('#changeDisplay').val(returnChange);
			},
			error: function (xhr) {
				$('#displayMessage').append(xhr.responseJSON.message);
			}
		});
	}
});
function getChange() {
	$('#changeButton').click(function () {
		$('#changeDisplay').val('');
		total = 0;

		$('#item').val('');

		loadProducts();
	})
}
