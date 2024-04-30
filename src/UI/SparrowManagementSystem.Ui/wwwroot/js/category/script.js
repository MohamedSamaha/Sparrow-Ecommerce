function createCategory() {
    var categoryName = document.getElementById('categoryNameId').value;
    var categoryType = document.getElementById('categoryTypeId').value;
    var categoryDescription = document.getElementById('categoryDescriptionId').value;

	if (categoryName === '' || categoryType === '' || categoryDescription === '') {
		
		document.getElementById('dangerAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Category/Create", data: {
				categoryName: categoryName,
				categoryType: categoryType,
				categoryDescription: categoryDescription
			}, success: function () {
				// Reload the page or update the UI as needed
				
				swal("Category Successfully Added!", `Category name: ${categoryName} of Type : ${categoryType} And Description ${categoryDescription}`, {
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
		
		document.getElementById('dangerAlert').hidden = true;
		categoryName.value = '';
		categoryType.value = '';
		categoryDescription.value = '';

	}
}

function deleteCategoryFunc(Id) {
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
				type: 'POST', url: "/Category/Delete", data: {
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

function editCategory(Id)
{
	var categoryName = document.getElementById(`categoryNameId-${Id}`).value;
	var categoryType = document.getElementById(`categoryTypeId-${Id}`).value;
	var categoryDescription = document.getElementById(`categoryDescriptionId-${Id}`).value;
	if (categoryName === '' || categoryType === '' || categoryDescription === '') {

		document.getElementById('dangerEditAlert').hidden = false;
	} else {
$.ajax({
		type: 'POST', url: "/Category/Edit", data: {
			categoryName: categoryName,
			categoryType: categoryType,
			categoryDescription: categoryDescription,
			Id: Id
		}, success: function () {
			// Reload the page or update the UI as needed

			swal("Category Successfully Updated", {
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
			$("#categoryNameId").val(),
			$("#categoryTypeId").val(),
			$("#categoryDescriptionId").val(),
			action
		]);
		$('#addRowModal').modal('hide');

	});
});

function hardRefresh() {   // Create a new KeyboardEvent with the key property set to "F5" and Ctrl key pressed 
	var event = new KeyboardEvent('keydown', { key: 'F5', code: 'F5', keyCode: 116, ctrlKey: true, metaKey: true, });   // Dispatch the event to the document 
	document.dispatchEvent(event);
}
