window.bootBlazor = {
    progressBar : {
        onValueChanged: function (id, percentage) {
            var ele = document.getElementById(id);

            var bar = ele.getElementsByClassName('progress-bar')[0];
            bar.style = 'width:' + percentage + '%';

        }
    }
}