app['/host/controls/summary-errors/'] = (function () {
    var _ID_ELEMENT = 'app--id--host--control--summary-errors';

    function start(index, containerId, funcSetup, funcRender, funcNext) {
        var _control = {
            elementId: _ID_ELEMENT + index,
            index: index
        };

        function init() {
            funcSetup(_control, funcNext);
        }

        app.data.load(
            'host/controls/summary-errors/host-control-summary-errors.template.html',
            function(data, funcNext) {
                var reElement =  new RegExp('"' + _ID_ELEMENT+ '"', 'g');

                data = data.replace(
                    reElement,
                    _control.elementId
                );

                var containers = {};

                containers[containerId] = [
                    data,
                    init,
                    funcNext
                ];

                funcRender(containers);
            },
            funcNext
        );
    }

    return {
      start: start
    };
})();
