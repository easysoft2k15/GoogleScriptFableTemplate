**Disclaimer: I just start testing and I only made this little program compile and run. So don't blame me if everything blow up!!**

### Setup npm package
1. Install npm package
```
npm install
```
### Write Your .fsx FSharp file and compile it
1. Grab the resulting bundle-patch.js
2. Please make sure globalObj is set to ```{}``` in the generated code (```Window```, ```global``` and ```self``` are not defined in Google Script):
```
var fableGlobal = function () {
    var globalObj = typeof window !== "undefined" ? window
        : (typeof global !== "undefined" ? global
            : (typeof self !== "undefined" ? self : {}));
```
Newer version of Fable should take care of this

### Setup Google Script
1. Create a function in Google Script and past the code from bundle-patch.js
2. Include the library with the necessary polyfill. You may use the one a created (key: ```M726KwLBDta3Y_kNftg3RGylHpT6My3TR```) or build Your own.
   Please note that here the generated bundle-patch.js assume that You imported the library in Your Google Script with the prefix  ``` polyfill ```


### VISUAL STUDIO 2015 SETUP (this is already done in this project)
1. Grab Google Script type definition (TypeScript) from: https://github.com/DefinitelyTyped/DefinitelyTyped
2. Install ts2Fable package:
```
npm i ts2fable --global
```
3. Convert *.d.ts type file
3. Include converted .fs file into the VS2015 project

### NOTE 1:
If You want to create Your own polyfill library You may do it like this:
```
(function()
 {
    var result = UrlFetchApp.fetch('https://cdnjs.cloudflare.com/ajax/libs/babel-polyfill/6.22.0/polyfill.js');
    eval (result.getContentText());
 }());
```

__Enjoy!!__

__Thanks to:__
1. [Alonso Garcia](https://www.npmjs.com/~alfonsogarciacaro) for his help and time!
2. [Fable.io](http://http://fable.io/)
2. [Bruce Mcpherson](http://ramblings.mcpher.com/Home/excelquirks/gassnips/promisesappsscript) for info on how to write library in Google Script
	


