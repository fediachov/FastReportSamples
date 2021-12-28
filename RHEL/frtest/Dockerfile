FROM registry.redhat.io/ubi8/dotnet-60-runtime AS base
USER 0
RUN dnf -y update \
    && dnf -y install https://dl.fedoraproject.org/pub/epel/epel-release-latest-8.noarch.rpm \
    && dnf -y install glib2-devel glibc-devel autoconf libtool automake gcc gcc-c++ make \
    && dnf -y install gettext git cairo-devel pango-devel libjpeg-turbo-devel libtiff-devel libexif-devel \
    && dnf -y install wget rpm-build cabextract ttmkfdir \
    && wget https://sourceforge.net/projects/mscorefonts2/files/rpms/msttcore-fonts-installer-2.6-1.noarch.rpm/download -O msttcore-fonts-installer-2.6-1.noarch.rpm \
    && dnf -y install msttcore-fonts-installer-2.6-1.noarch.rpm && fc-cache /usr/share/fonts
WORKDIR /var/customlibgdiplus
RUN git clone https://github.com/mono/libgdiplus.git
WORKDIR /var/customlibgdiplus/libgdiplus
RUN ./autogen.sh --with-pango --prefix=/usr && make && make install && make clean && dnf -y clean all && rm -rf /var/cache/dnf/*

FROM registry.redhat.io/ubi8/dotnet-60 AS build
USER 0
WORKDIR /src
COPY . .
RUN dotnet restore \
    && dotnet publish -c Release --no-restore -o publish -r linux-x64 --self-contained false /p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=build /src/publish .
EXPOSE 8080
ENTRYPOINT ["/app/frtest"]
