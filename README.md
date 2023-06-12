# Instruccions instal·lació - Linux (Debian 11)

Font: https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian#debian-11

wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

apt-get update && \
  apt-get install -y dotnet-sdk-7.0
  
apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-7.0

apt install dotnet-sdk-7.0

# Creació aplicació
Font: https://learn.microsoft.com/en-us/dotnet/standard/get-started#tutorials-for-creating-apps

dotnet new console --framework net7.0   # Aplicació de consola

# Creació .gitignore

![image](https://github.com/projecteinf/VideoComposition/assets/96139692/8b82e9fc-ccda-42be-b914-b55f8b6f18da)

# Execució programa

![image](https://github.com/projecteinf/VideoComposition/assets/96139692/264b7074-ff05-4ee1-bd5d-25746cbd0f37)

# Dades retornades per un fitxer de video

ffmpeg version 4.3.6-0+deb11u1 Copyright (c) 2000-2023 the FFmpeg developers
  built with gcc 10 (Debian 10.2.1-6)
  configuration: --prefix=/usr --extra-version=0+deb11u1 --toolchain=hardened --libdir=/usr/lib/x86_64-linux-gnu --incdir=/usr/include/x86_64-linux-gnu --arch=amd64 --enable-gpl --disable-stripping --enable-avresample --disable-filter=resample --enable-gnutls --enable-ladspa --enable-libaom --enable-libass --enable-libbluray --enable-libbs2b --enable-libcaca --enable-libcdio --enable-libcodec2 --enable-libdav1d --enable-libflite --enable-libfontconfig --enable-libfreetype --enable-libfribidi --enable-libgme --enable-libgsm --enable-libjack --enable-libmp3lame --enable-libmysofa --enable-libopenjpeg --enable-libopenmpt --enable-libopus --enable-libpulse --enable-librabbitmq --enable-librsvg --enable-librubberband --enable-libshine --enable-libsnappy --enable-libsoxr --enable-libspeex --enable-libsrt --enable-libssh --enable-libtheora --enable-libtwolame --enable-libvidstab --enable-libvorbis --enable-libvpx --enable-libwavpack --enable-libwebp --enable-libx265 --enable-libxml2 --enable-libxvid --enable-libzmq --enable-libzvbi --enable-lv2 --enable-omx --enable-openal --enable-opencl --enable-opengl --enable-sdl2 --enable-pocketsphinx --enable-libmfx --enable-libdc1394 --enable-libdrm --enable-libiec61883 --enable-chromaprint --enable-frei0r --enable-libx264 --enable-shared
  libavutil      56. 51.100 / 56. 51.100
  libavcodec     58. 91.100 / 58. 91.100
  libavformat    58. 45.100 / 58. 45.100
  libavdevice    58. 10.100 / 58. 10.100
  libavfilter     7. 85.100 /  7. 85.100
  libavresample   4.  0.  0 /  4.  0.  0
  libswscale      5.  7.100 /  5.  7.100
  libswresample   3.  7.100 /  3.  7.100
  libpostproc    55.  7.100 / 55.  7.100
Input #0, mov,mp4,m4a,3gp,3g2,mj2, from './videos/_import_615163540096e1.68968110.mov':
  Metadata:
    major_brand     : qt  
    minor_version   : 537199360
    compatible_brands: qt  
    creation_time   : 2017-02-09T12:13:55.000000Z
  Duration: 00:00:15.03, start: 0.000000, bitrate: 856660 kb/s
    Stream #0:0(eng): Video: prores (HQ) (apch / 0x68637061), yuv422p10le(tv, bt709, progressive), 3840x2160, 856102 kb/s, SAR 1:1 DAR 16:9, 30 fps, 30 tbr, 30 tbn, 30 tbc (default)
    Metadata:
      creation_time   : 2017-02-09T12:13:55.000000Z
      handler_name    : Apple Video Media Handler
      encoder         : Apple ProRes 422 (HQ)
      timecode        : 00:00:00:00
    Stream #0:1(eng): Data: none (tmcd / 0x64636D74), 0 kb/s (default)
    Metadata:
      creation_time   : 2017-02-09T12:13:55.000000Z
      handler_name    : Time Code Media Handler
      timecode        : 00:00:00:00
Stream mapping:
  Stream #0:0 -> #0:0 (prores (native) -> wrapped_avframe (native))
Press [q] to stop, [?] for help
Output #0, null, to 'pipe:':
  Metadata:
    major_brand     : qt  
    minor_version   : 537199360
    compatible_brands: qt  
    encoder         : Lavf58.45.100
    Stream #0:0(eng): Video: wrapped_avframe, yuv422p10le, 3840x2160 [SAR 1:1 DAR 16:9], q=2-31, 200 kb/s, 30 fps, 30 tbn, 30 tbc (default)
    Metadata:
      creation_time   : 2017-02-09T12:13:55.000000Z
      handler_name    : Apple Video Media Handler
      timecode        : 00:00:00:00
      encoder         : Lavc58.91.100 wrapped_avframe
frame=  451 fps= 56 q=-0.0 Lsize=N/A time=00:00:15.03 bitrate=N/A speed=1.87x    
video:236kB audio:0kB subtitle:0kB other streams:0kB global headers:0kB muxing overhead: unknown

# VideoComposition

