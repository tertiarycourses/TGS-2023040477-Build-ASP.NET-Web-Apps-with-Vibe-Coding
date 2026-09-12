#!/bin/sh
set -eu
base="${1:-http://localhost:8080}"
curl -fsS "$base/health/live" >/dev/null
curl -fsS "$base/health/ready" >/dev/null
curl -fsS "$base/api/contacts" >/dev/null
printf 'LocalCRM smoke checks passed for %s
' "$base"
