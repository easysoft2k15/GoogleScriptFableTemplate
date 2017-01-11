(function (global, factory) {
  if (typeof define === "function" && define.amd) {
    define(["exports", "fable-core"], factory);
  } else if (typeof exports !== "undefined") {
    factory(exports, require("fable-core"));
  } else {
    var mod = {
      exports: {}
    };
    factory(mod.exports, global.fableCore);
    global.googleAppsScriptBaseDTs = mod.exports;
  }
})(this, function (exports, _fableCore) {
  "use strict";

  Object.defineProperty(exports, "__esModule", {
    value: true
  });
  exports.GoogleAppsScript = undefined;

  function _classCallCheck(instance, Constructor) {
    if (!(instance instanceof Constructor)) {
      throw new TypeError("Cannot call a class as a function");
    }
  }

  var GoogleAppsScript = exports.GoogleAppsScript = function ($exports) {
    var Base = $exports.Base = function ($exports) {
      var Button = $exports.Button = function Button() {
        _classCallCheck(this, Button);
      };

      _fableCore.Util.setInterfaces(Button.prototype, [], "Fable.Import.GoogleAppsScript.Base.Button");

      var ButtonSet = $exports.ButtonSet = function ButtonSet() {
        _classCallCheck(this, ButtonSet);
      };

      _fableCore.Util.setInterfaces(ButtonSet.prototype, [], "Fable.Import.GoogleAppsScript.Base.ButtonSet");

      var MimeType = $exports.MimeType = function MimeType() {
        _classCallCheck(this, MimeType);
      };

      _fableCore.Util.setInterfaces(MimeType.prototype, [], "Fable.Import.GoogleAppsScript.Base.MimeType");

      var Month = $exports.Month = function Month() {
        _classCallCheck(this, Month);
      };

      _fableCore.Util.setInterfaces(Month.prototype, [], "Fable.Import.GoogleAppsScript.Base.Month");

      var Weekday = $exports.Weekday = function Weekday() {
        _classCallCheck(this, Weekday);
      };

      _fableCore.Util.setInterfaces(Weekday.prototype, [], "Fable.Import.GoogleAppsScript.Base.Weekday");

      return $exports;
    }({});

    return $exports;
  }({});
});