function addProductQuantity(Id,TotalItemPrice){
    var itemProductCounter = document.getElementById(`inputItemCount-${Id}`).value;
 
    // Get the table cell by its ID
    var outputCell = document.getElementById(`outputCell-${Id}`);
	var price = itemProductCounter * TotalItemPrice;
	outputCell.textContent = price.toFixed(2);

	$.ajax({
		type: 'POST', url: "/Cart/Edit", data: {
			Id: Id,
			TotalItemPrice: TotalItemPrice,
			ItemProductCounter: itemProductCounter

		}, success: function () {
			
		}, error: function (error) {

		}
	});

}
function deleteCartFunc(Id) {
	swal({
		title: 'Are you sure?',
		text: "You won't be able to revert this!",
		type: 'warning',
		buttons: {
			cancel: {
				visible: true,
				text: 'No, cancel!',
				className: 'btn btn-success'
			},
			confirm: {
				text: 'Yes, delete it!',
				className: 'btn btn-danger'
			}
		}
	}).then((willDelete) => {


		if (willDelete) {
			$.ajax({
				type: 'POST', url: "/Cart/Delete", data: {
					Id: Id
				}, success: function () {
					window.location.reload();
				}, error: function (error) {

				}
			});
			swal("Poof! Your Cart item has been deleted!", {
				icon: "success",
				buttons: {
					confirm: {
						className: 'btn btn-success'
					}
				}
			});
		} else {
			swal("Your Cart item is safe!", {
				buttons: {
					confirm: {
						className: 'btn btn-success'
					}
				}
			});
		}
	});

}