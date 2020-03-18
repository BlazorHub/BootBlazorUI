window.Fyun = {
	modal: {
		show: function (id) {
			
			//let body = document.querySelector('body');
			//body.className = 'modal-open';
			//body.appendChild('<div class="modal-backdrop fade show"></div>');

			//let modalObj = document.getElementById(id);
			//modalObj.style.display = 'block';
			////$('#' + id).modal('show');

			BSN.Modal(id).show();
		}
	}
}

