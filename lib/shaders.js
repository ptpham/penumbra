
var glslify = require('glslify');

module.exports = {
  vs: {
    simple: glslify('../glsl/simple.vs')
  },
  fs: {
    red: glslify('../glsl/red.fs'),
    po1: glslify('../glsl/po1.fs'),
    po4: glslify('../glsl/po4.fs'),
    so1: glslify('../glsl/so1.fs')
  }
};

