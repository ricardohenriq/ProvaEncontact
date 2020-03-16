Recados_VerRecados = function ($el) {

    "use strict";
    if (!$el)
        throw "O Item não foi definido.";

    this._$el = $el;
    this._el = $el[0];

    this._$elTabLink = this._$el.find(".tablinks");
    this._$elTabConteudo = this._$el.find(".tabcontent");
    this._$elRecadosAgrupados = this._$el.find(".recados-agrupados");

    this._inicialize();
};

Recados_VerRecados.prototype = {

    _inicialize: function () {
        this._preparaComponente();
        this._ligaEventos();
    },

    _ligaEventos: function () {
        var _this = this;

        this._$elTabLink.on("click", function () {
            _this._tabLinkClicado(this);
        });
    },

    _preparaComponente: function () {
        this._exibaPrimeiroRecado();
        this._marquePrimeiraTab();
    },

    _tabLinkClicado: function (tabLinkClicado) {
        this._exibirRecadosDoAgrupamento(tabLinkClicado);
        this._marcarAgrupamentoSelecionado(tabLinkClicado);
    },

    _exibirRecadosDoAgrupamento: function (tabLinkClicado) {
        this._$elTabConteudo.hide();
        this._$el.find("div#" + $(tabLinkClicado).attr("id")).show();
    },

    _marcarAgrupamentoSelecionado: function (tabLinkClicado) {
        this._$elTabLink.removeClass("active");
        $(tabLinkClicado).addClass("active");

        this._$elRecadosAgrupados.hide();
        $("[data-id='" + $(tabLinkClicado).attr("id") + "']").show();
    },

    _exibaPrimeiroRecado: function () {
        this._$elTabConteudo.hide();
        $(this._$elTabConteudo[0]).show();
    },

    _marquePrimeiraTab: function () {
        this._$elTabLink.removeClass("active");
        $(this._$elTabLink[0]).addClass("active");

        this._$elRecadosAgrupados.hide();
        $("[data-id='" + $(this._$elTabLink[0]).attr("id") + "']").show();
    }
};