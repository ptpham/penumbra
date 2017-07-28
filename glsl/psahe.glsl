
float projected_spherical_area_with_horizon_estimate(float ndot, float gamma) {
  return max(2.0*(ndot+0.5)/3.0, 0.0) * (1.0-cos(gamma));
}

#pragma glslify: export(projected_spherical_area_with_horizon_estimate)

