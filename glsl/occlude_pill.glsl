
#pragma glslify: psahe = require('./psahe.glsl')

float occlude_pill(vec3 start, vec3 end, float radius, vec3 position, vec3 normal) {
  vec3 d0 = start - position;
  vec3 d1 = end - position;
  vec3 dir = end - start;

  float l0 = length(d0);
  float l1 = length(d1);
  float ld = length(dir);

  d0 /= l0;
  d1 /= l1;
  dir /= ld;

  float t = clamp(dot(position - start, dir), 0.0, ld);
  vec3 approach = t*dir + start - position;
  float la = length(approach);
  approach = approach / la;

  float gammaa = asin(min(radius/la, 1.0));
  float gamma0 = asin(min(radius/l0, 1.0));
  float gamma1 = asin(min(radius/l1, 1.0));

  float theta0_raw = acos(clamp(dot(d0, approach), -1.0, 1.0));
  float theta1_raw = acos(clamp(dot(d1, approach), -1.0, 1.0));

  float theta0 = max(theta0_raw - 0.5*gammaa, 0.0);
  float theta1 = max(theta1_raw - 0.5*gammaa, 0.0);

  float ndot0 = dot(normal, d0);
  float ndot1 = dot(normal, d1);
  float ndota = dot(normal, approach);

  float st0 = psahe(ndot0, gamma0);
  float st1 = psahe(ndot1, gamma1);
  float sta = psahe(ndota, gammaa);

  return sta + 0.5*theta0*(sta + st0) + 0.5*theta1*(sta + st1);
}

#pragma glslify: export(occlude_pill)

