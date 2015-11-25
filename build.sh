#!/bin/bash
cd build-tools
mono --runtime=v4.0 nuget.exe install FAKE -Version 4.9.0
cd ..
mono --runtime=v4.0 build-tools/FAKE.4.9.0/tools/FAKE.exe build-tools/build.fsx $@
