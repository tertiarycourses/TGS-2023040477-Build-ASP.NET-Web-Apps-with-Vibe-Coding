#!/bin/sh
set -eu
cd "$(dirname "$0")/../src/LocalCRM"
exec dotnet run --urls http://localhost:5105
