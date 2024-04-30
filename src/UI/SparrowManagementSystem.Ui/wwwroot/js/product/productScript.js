function checkFileCount() {
	var input = document.getElementById('productImagesId');
	var fileCount = input.files.length;

	// Set your desired file limit here (e.g., 4)
	var fileLimit = 5;

	if (fileCount > fileLimit) {
		swal('You can only upload up to ' + fileLimit + ' files.', {
			icon: "error",
			buttons: {
				confirm: {
					className: 'btn btn-danger'
				}
			}
		});
		// Clear the file input to prevent further uploads
		input.value = '';
	}
}

function deleteProductFunc(Id) {
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
				type: 'POST', url: "/Product/Delete", data: {
					Id: Id
				}, success: function () {
					window.location.reload();
				}, error: function (error) {

				}
			});
			swal("Poof! Your imaginary file has been deleted!", {
				icon: "success",
				buttons: {
					confirm: {
						className: 'btn btn-success'
					}
				}
			});
		} else {
			swal("Your imaginary file is safe!", {
				buttons: {
					confirm: {
						className: 'btn btn-success'
					}
				}
			});
		}
	});

}

function editProduct() {

	var productName = document.getElementById('productNameId').value;
	var productType = document.getElementById('productTypeId').value;
	var productDescription = document.getElementById('productDescriptionId').value;


	if (productName === '' || productType === '' || productDescription === '') {

		document.getElementById('dangerAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Product/Edit",
			success: function () {
				// Reload the page or update the UI as needed

				swal("Product Successfully Modified!", {
					icon: "success",
					buttons: {
						confirm: {
							className: 'btn btn-success'
						}
					},
				}).then(
					function () {
						window.location.reload();
					});
			}, error: function (error) {
				swal('Something Went Wrong!', {
					icon: "error",
					buttons: {
						confirm: {
							className: 'btn btn-error'
						}
					},
				}).then(
					function () {
						window.location.reload();
					});
			}
		});
	}

}
function createProduct() {
	var productName = document.getElementById('productNameId').value;
	var productType = document.getElementById('productTypeId').value;
	var productDescription = document.getElementById('productDescriptionId').value;


	if (productName === '' || productType === '' || productDescription === '') {

		document.getElementById('dangerAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Product/Create",
			success: function () {
				// Reload the page or update the UI as needed

				swal("Product Successfully Added!", {
					icon: "success",
					buttons: {
						confirm: {
							className: 'btn btn-success'
						}
					},
				}).then(
					function () {
						window.location.reload();
					});
			}, error: function (error) {
				swal('Something Went Wrong!', {
					icon: "error",
					buttons: {
						confirm: {
							className: 'btn btn-error'
						}
					},
				}).then(
					function () {
						window.location.reload();
					});
			}
		});
	}


}


$(document).ready(function () {
	$('#basic-datatables').DataTable({
	});

	$('#multi-filter-select').DataTable({
		"pageLength": 5,
		initComplete: function () {
			this.api().columns().every(function () {
				var column = this;
				var select = $('<select class="form-control"><option value=""></option></select>')
					.appendTo($(column.footer()).empty())
					.on('change', function () {
						var val = $.fn.dataTable.util.escapeRegex(
							$(this).val()
						);

						column
							.search(val ? '^' + val + '$' : '', true, false)
							.draw();
					});

				column.data().unique().sort().each(function (d, j) {
					select.append('<option value="' + d + '">' + d + '</option>')
				});
			});
		}
	});

	// Add Row
	$('#add-row').DataTable({
		"pageLength": 5,
	});

	var action = '<td> <div class="form-button-action"> <button type="button" data-toggle="tooltip" title="" class="btn btn-link btn-primary btn-lg" data-original-title="Edit Task"> <i class="fa fa-edit"></i> </button> <button type="button" data-toggle="tooltip" title="" class="btn btn-link btn-danger" data-original-title="Remove"> <i class="fa fa-times"></i> </button> </div> </td>';

	$('#addRowButton').click(function () {
		$('#add-row').dataTable().fnAddData([
			$("#productNameId").val(),
			$("#productBrandId").val(),
			$("#productCodeId").val(),
			$("#productPriceId").val(),
			$("#productSizeId").val(),
			$("#vendorNameId").val(),
			$("#productColorId").val(),
			$("#productRatingId").val(),
			$("#productDetailsId").val(),
			$("#productCountId").val(),
			$("#productDiscountId").val(),
			$("#productMaterialId").val(),
			$("#productCategoryId").val(),
			$("#productDescription").val(),
			action
		]);
		$('#addRowModal').modal('hide');

	});
});

