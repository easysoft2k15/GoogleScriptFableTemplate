**Disclaimer: I just start testing and I only made this little program compile and run. So don't blame me if everything blow up!!**

### MODIFY AND COMPILE fable-core.ts
1. Install Babel
npm i babel-cli --global
2.  Install Babel UMD Transform:
npm install --save-dev babel-plugin-transform-es2015-modules-umd
3. Modify fable-core.ts in order to get rid of duplicate name. All modified name have been prefixed with "GAS_".
Moreover the function "fableGlobal" has been modify to return "this" instead of null at the very end.
4. compile fable-core-ts with the following setup
```
///tsconfig.json
{
    "compilerOptions": {
        "target": "es5",
        "module": "commonjs",
        "noImplicitAny": true,
        "noImplicitReturns": true
    },
    "files": [
        "fable-core.ts"
    ]
}
```
### GET THE NECESSARY POLYFILL (Google Script are not es6 compatible)
1. Install Babel polyfill:
npm install --save-dev babel-polyfill
2. Grab the file polyfill.js on the "babel-polyfill\babel-polyfill\disp" folder

### CREATE THE GOOGLE APP FUNCTION
1. Post-process the resulting polyfill.js and fable-core.js with Babel:
babel polyfill.js fable-core.js --plugins babel-plugin-transform-es2015-modules-umd -o fable-core-umd.js
2. Simply copy past content of "fable-core-umd.js"

### VISUAL STUDIO 2015 SETUP
1. Grab Google Script type definition (TypeScript) from: https://github.com/DefinitelyTyped/DefinitelyTyped
2. Install ts2Fable package:
npm i ts2fable --global
3. Convert *.d.ts type file
3. Include converted .fs file into the VS2015 project

### NOTE 1:
If You want to use my library You will find it with the following key: 
 MJ8B3G3tARrY3vnr-flBBaylHpT6My3TR

### NOTE 2: 
Please remember to change "this" -> "fableCore" (o whatever is the name of the library You are using) in Fable generated code:
```
function myFunction() {
(function (global, factory) {
    if (typeof define === "function" && define.amd) {
        define(["fable-core"], factory);
    } else if (typeof exports !== "undefined") {
        factory(require("fable-core"));
    } else {
        var mod = {
            exports: {}
        };
        factory(global.fableCore);
        global.MyScript = mod.exports;
    }
})(fableCore, function (_fableCore) {
    "use strict";

    _fableCore.List.map(function (i) {
        return Logger.log(i);
    }, _fableCore.Seq.toList(_fableCore.Seq.range(1, 10)));
});
}
```

### NOTE 3: some opinionable changed ......
1. in fable-core.ts I changed "catch" => "GAS_catch" due to Google Script compleining with name resolution:
  static awaitPromise<T>(p: Promise<T>) {
    return Async.fromContinuations((conts: Array<Continuation<T>>) =>
      p.then(conts[0]).GAS_catch(err =>
        (err == "cancelled" ? conts[2] : conts[1])(err))); 

__Enjoy!!__

__Thanks to:__
1. Fable:
	http://http://fable.io/
2. For some inspiration:
	http://ramblings.mcpher.com/Home/excelquirks/gassnips/promisesappsscript



